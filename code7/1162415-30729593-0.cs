    var valOne = 1.1234560M; // Decimal.Round(1.1234560M, 6);  Don't round.
    var valTwo = 1.1234569M; // Decimal.Round(1.1234569M, 6);  Don't round
    
    if (Math.Abs(valOne - valTwo) >= 0.000001M) // Six digits after decimal in epsilon
    {
        Console.WriteLine("Values differ");
    }
    else
    {
        Console.WriteLine("Values are the same");
    }
