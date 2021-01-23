    for (int i = 0; i < N; i++)
    {
        check = false; // ignore this one.
        Console.WriteLine("Student {0}", i + 1);
        Console.Write("\t \t Name: ");
        string input = Console.ReadLine();
    you are missing line below.
         student[i]= new student();
        student[i].studentName = input; 
       
    }
