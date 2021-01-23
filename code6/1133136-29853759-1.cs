    public static void Main()
    {
        var Student1 = new Student {Name = "John"};
        var Student2 = new Student {Name = "Joe"};
        var Student3 = new Student {Name = "Jacob"};
        foreach (var student in Student.AllStudents)
        {
            Console.WriteLine(student.Name);
        }
    }
