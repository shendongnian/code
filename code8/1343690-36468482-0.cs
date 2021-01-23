    for (int i = 0; i < matches.Size; i++)
    {
        var a = matches[i].ToArray();
        if (mask.GetData(i)[0] == 0)
            continue;
        foreach (var e in a)
        {
            Point p = new Point(e.TrainIdx, e.QueryIdx);
            Console.WriteLine(string.Format("Point: {0}", p));
        }
        Console.WriteLine("-----------------------");
    }
