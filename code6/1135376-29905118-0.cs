    foreach (var someObject in students)
    {
        // Try to cast the object as a Student
        var studentCast = someObject as Student;
        // If it's not null, the cast succeeded
        if (studentCast != null)
        {
            Console.WriteLine("{0} {1}", studentCast.FirstName, studentCast.LastName);
        }
    }
