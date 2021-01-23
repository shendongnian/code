    double mealCoast = double.Parse(Console.ReadLine()); // mealCoast = 12.
    int tipPercent = int.Parse(Console.ReadLine()); // tipPercent = 20
    int taxPercent = int.Parse(Console.ReadLine()); // taxPercent = 8
    //Calculating % 
    // Convert.ToInt16(mealCoast) will give you 12
    // you are using integer division here, no digits preserved after period.
    tipPercent = Convert.ToInt16(mealCoast) * (tipPercent) / 100; // 12 * 20 / 100 = 2
    taxPercent = Convert.ToInt16(mealCoast) * (taxPercent) / 100; // 12 * 8 / 100 = 0
    // 12 + 2 + 0 = 14
    int totalCast = Convert.ToInt16(mealCoast) + tipPercent + taxPercent; // 14
    Console.WriteLine("The total meal cost is {0} dollars.", totalCast); 
    Console.ReadKey();
