    int x1 = 0;
    int y1 = 0;
    int x2 = 0;
    int y2 = 0;
    int option = 0;
    Console.WriteLine("Type in your 1st X coordinate");
    while (!int.TryParse(Console.ReadLine(), out x1))
        Console.WriteLine("That number is invalid, please try again:");
    Console.WriteLine("Type in your 1st Y coordinate");
    while (!int.TryParse(Console.ReadLine(), out y1))
        Console.WriteLine("That number is invalid, please try again:");
    Console.WriteLine("Type in your 2nd X coordinate");
    while (!int.TryParse(Console.ReadLine(), out x2))
        Console.WriteLine("That number is invalid, please try again:");
    Console.WriteLine("Type in your 2nd Y coordinate");
    while (!int.TryParse(Console.ReadLine(), out y2))
        Console.WriteLine("That number is invalid, please try again:");
    Console.WriteLine("Do you want to use the distance or midpoint formula.(Type 0 for distance and 1  for midpoint)");
    while (!int.TryParse(Console.ReadLine(), out option))
        Console.WriteLine("That number is invalid, please try again:");
    int x2x1 = x2 - x1;
    int x2x1Squared = x2x1 * x2x1;
    int y2y1 = y2 - y1;
    int y2y1Squared = y2y1 * y2y1;
    int addedSquaredValues = x2x1Squared + y2y1Squared;
    if (option == 0)
        Console.WriteLine("Distance (Square Root) of {0} is {1}", addedSquaredValues, Math.Sqrt(addedSquaredValues));
    Console.ReadLine();
