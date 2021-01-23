    Console.WriteLine("Type in your 1st X coordinate");
    double x1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Type in your 1st Y coordinate");
    double y1 = Convert.ToInt32(Console.ReadLine());
            
    Console.WriteLine("Type in your 2nd X coordinate");
    double x2 = Convert.ToInt32(Console.ReadLine());
            
    Console.WriteLine("Type in your 2nd Y coordinate");
    double y2 = Convert.ToInt32(Console.ReadLine());
            
    Console.WriteLine("Do you want to use the distance or midpodouble formula.(Type 0 for distance and 1  for midpoint)");
    double forumlaSelection = Convert.ToInt32(Console.ReadLine());
    double dx = x1 - x2;
    double dxSquared = dx * dx;
    double dy = y1 - y2;
    double dySquared = dy * dy;
    double dxSquaredPlusDySquared = dxSquared + dySquared;
    if (forumlaSelection == 0)
    {
        Console.Out.Write("Square Root of");
        Console.Out.Write(Math.Sqrt(dxSquaredPlusDySquared));
    }
