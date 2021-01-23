    for (int grade = 0; grade < studentGrades.GetLength(1); grade++)
    {
        for (int name = 0; name < studentGrades.GetLength(0); name++)
        {
            Console.Write("{0, -15}", studentGrades[name, grade]);
        }
        Console.WriteLine();
    }
