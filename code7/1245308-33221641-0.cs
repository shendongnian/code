    for (int i = 0; i < 20; i++)
    {
        aStudent[i] = new Student();
        Console.WriteLine("Please enter the 2 grades for student num " + i+ " \nif there is no grade , enter -1");
        aStudent[i].FirstGrade = int.Parse(Console.ReadLine());
        aStudent[i].SecondGrade = int.Parse(Console.ReadLine());
    }
