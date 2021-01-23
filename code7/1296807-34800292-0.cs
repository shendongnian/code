    public static void AddStudent(Func<string> consoleReader)
    {
        Student student = new Student();
        
        Console.WriteLine("Enter student name:");
        student.Name = Console.ReadLine();
        // ...        
    }
