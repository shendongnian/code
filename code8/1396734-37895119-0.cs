    Student[] student = new Student[N];
    // the N is determined by a previous block    of code.
    for (int i = 0; i < N; i++)
    {
        student[i] = new Student();
        check = false; // ignore this one.
        Console.WriteLine("Student {0}", i + 1);
        Console.Write("\t \t Name: ");
        string input = Console.ReadLine();
        student[i].studentName = input; 
    }
