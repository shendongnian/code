    public static void Main()
    {
        var student1 = new Student {Name = "John"};
        var student2 = new Student {Name = "Joe"};
        var student3 = new Student {Name = "Jacob"};
        foreach (var student in Student.AllStudents)
        {
            Console.WriteLine(student.Name);
        }
    }
