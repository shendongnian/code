    foreach(var pedestrian in peds)
    {
        Console.WriteLine(pedestrian.Name);
        Console.WriteLine(string.Format("{0} {1}", pedestrian.InitialPosition.X, pedestrian.InitialPosition.Y));
        foreach (var final in pedestrian.FinalPositions)
            Console.WriteLine(string.Format("{0} {1} {2}", final.X, final.Y, final.Time));
    }
