    public void getStudent()
    {
        var student = new Student();
        Console.Write("Enter Your First Name: ");
        student.First_Name = Console.ReadLine();
        Console.Write("Enter Your Last Name: ");
        student.Last_Name = Console.ReadLine();
       studentList.Add(student);
    }
