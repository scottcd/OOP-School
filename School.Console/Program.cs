/***** Program Logic *****/
Class myClass = new Class(
    new Teacher("Danny", "Bronco"),
    new List<Student> {
        new Student("Kyle", "Manchester"),
        new Student("Stevie", "Osbourne"),
        new Student("Ada", "Hoover"),
        new Student("Edsgar", "Torvalds"),
        new Student("Sully", "McCowski"),
    }
        );

Console.WriteLine(myClass);

foreach (var student in myClass.Students) {
    Console.WriteLine(student.SubmitAssignment("Programming Lab", myClass.Teacher));
}

Console.WriteLine(myClass.Teacher.GradeAssignment());


/***** Classes and Interfaces  *****/
public class Person : IAttend
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Person(string firstName, string lastName) {
        FirstName = firstName;
        LastName = lastName;
    }

    public virtual string AttendClass()
    {
        return $"Attending class";
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}

public interface IAttend
{
    string AttendClass();
}

public interface IGrade {
    string AcceptAssignment(Assignment assignment);
    string GradeAssignment();
}

public interface ISubmit {
    string SubmitAssignment(string assignmentName, Teacher teacher);
}

public class Student : Person, ISubmit { 
    public Student(string firstName, string lastName) : base(firstName, lastName) {}
    
    public string SubmitAssignment(string assignmentName, Teacher teacher) {
        var assignment = new Assignment(assignmentName, this);
        teacher.AcceptAssignment(assignment);
        return $"Submitting {assignment.Name} to {teacher}";
    }
}

public class Teacher : Person, IGrade {
    public List<Assignment> Assignments { get; private set; }

    public Teacher(string firstName, string lastName) : base(firstName, lastName) {
        Assignments = new();
    }
    
    public string AcceptAssignment(Assignment assignment) {
        Assignments.Add(assignment);
        return $"Accepted {assignment}";
    }

    public string GradeAssignment() {
        string output = string.Empty;
        foreach (var assignment in Assignments) {
            output += $"Grading {assignment}\n";
        }

        output += $"Finished Grading Assignment!";      
        return output;
    }
}

public class Assignment {
    public string Name { get; private set; }
    public Student Student { get; private set; }

    public Assignment(string name, Student student) {
        Name = name;
        Student = student;
    }

    public override string ToString() {
        return $"{Name} by {Student}";
    }
}

public class Class {
    public Teacher Teacher { get; private set; }
    public List<Student> Students {get; private set;}

    public Class(Teacher teacher, List<Student> students) {
        Teacher = teacher;
        Students = students;
    }

    public override string ToString() {
        string output = string.Empty;
        output += $"Teacher: {Teacher}\n";
        output += $"Students:\n";
        for (int i = 0; i < Students.Count; i++) {
            output += $"  {i+1}. {Students[i]}\n";
        }

        return output; 
    }
}
