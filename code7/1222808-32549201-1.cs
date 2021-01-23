    if (totalPrice >= 20.00)
        Console.WriteLine(TipCalculator.over20(totalPrice));
    else if (totalPrice < 20)
        Console.WriteLine(TipCalculator.under20(totalPrice));
    else Console.WriteLine("Error. Please type in the value of the bill again");
