    int totalFinals = 0;
    foreach (var pedestrian in peds)
    {
        Console.WriteLine(string.Format("{0} has {1} final positions.", pedestrian.Name, pedestrian.FinalPositions.Length));
        Console.WriteLine(string.Format("{0} {1}", pedestrian.InitialPosition.X, pedestrian.InitialPosition.Y));
        foreach (var final in pedestrian.FinalPositions)
            Console.WriteLine(string.Format("{0} {1} {2}", final.X, final.Y, final.Time));
        totalFinals += pedestrian.FinalPositions.Length;
    }
    Console.WriteLine(string.Format("Total final positions = {0}", totalFinals));
