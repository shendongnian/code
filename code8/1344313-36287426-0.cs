    decimal mealCoast, tipPercent, taxPercent; //use decimal, probably is best
    bool mealCoastResult = decimal.TryParse(Console.ReadLine(), out mealCoast);
    bool tipPercentResult = decimal.TryParse(Console.ReadLine(), out tipPercent); //use TryParse
    bool taxPercentResult = decimal.TryParse(Console.ReadLine(), out taxPercent);
    //Input checking, check any parsing error
    if (!mealCoastResult || !tipPercentResult || !taxPercentResult){
        //do some error handlers
        return; //probably don't continue is good
    }
    //you could also put some while loop
    //Calculating % 
    tipPercent = mealCoast * tipPercent / 100;
    taxPercent = mealCoast * taxPercent / 100;
    decimal grandTotal = mealCoast + tipPercent + taxPercent;
    Console.WriteLine("The total meal cost is {0} dollars.", grandTotal);
    Console.ReadKey();
