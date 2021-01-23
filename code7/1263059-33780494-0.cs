       double double1;
        double double2;
        string text1;
        string text2;
      //The actual calculation
        System.Console.Write("Please input the kilogram price of candy: ");
        text1 = System.Console.ReadLine();
        double1 = double.Parse(text1);
        System.Console.Write("Please input the money allocated for candy ");
        text2 = System.Console.ReadLine();
        double2 = double.Parse(text2);
        System.Console.WriteLine("With the amount of money you input you would get " + (double2 / double1) + " kilos of candy.");
    
