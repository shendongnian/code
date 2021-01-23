    var valOne = Decimal.Round(1.1234560M, 6);    // Gives 1.123456
    var valTwo = Decimal.Round(1.1234569M, 6);    // Gives 1.123457
    
    if (Math.Abs(valOne - valTwo) >= 0.000001M)
    {
        Console.WriteLine("Values differ");
    }
    else
    {
        Console.WriteLine("Values are the same");
    }
