    // Take dice type from user
    Console.Write("Type of Dice: ");
    string input = Console.ReadLine();
    DiceType typeOfDice;
    // Try to parse the input and check if it could be an enum of the 
    // desidered type (Note user can also input "foursides" not just 4
    if (!Enum.TryParse<DiceType>(input, true, out typeOfDice) || 
        !Enum.IsDefined(typeof(DiceType), typeOfDice))
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
