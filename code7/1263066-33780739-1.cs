    //The variables
        decimal price; //CHANGE: descriptive variables!
        decimal allowance;
        string priceInput;
        string allowanceInput;
    //The actual calculation
        System.Console.Write("Please input the kilogram price of candy: ");
        priceInput = System.Console.ReadLine();
        price = decimal.Parse(priceInput); //CHANGE: use double.Parse here instead of int.Parse
        System.Console.Write("Please input the money allocated for candy ");
        allowanceInput = System.Console.ReadLine();
        allowance = decimal.Parse(allowanceInput); //CHANGE: use double.Parse here instead of int.Parse
        System.Console.WriteLine("With the amount of money you input you would get "
            + Math.Round(allowance / price, 2) + " kilos of candy.");
        //CHANGE: Divide the money you have by the amount it costs to get the KG of candy.
