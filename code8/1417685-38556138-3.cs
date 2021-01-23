    // Take dice type from user
    Console.Write("Type of Dice: ");
    string input = Console.ReadLine();
    DiceType typeOfDice;
    if (!Enum.TryParse<DiceType>(input, true, out typeOfDice) || !Enum.IsDefined(typeof(DiceType), typeOfDice))
        Console.WriteLine("That is not an acceptable die type. Please try again.");
    else
    {
       ....
       switch (typeOfDice)
       {
           case DiceType.FourSides:
               .....
               break;
           case DiceType.SixSides:
               .....
               break;
           ....
        }
