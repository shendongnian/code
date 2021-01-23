    List<TimeSpan> tsList = new List<TimeSpan>();
    for (int i = 1; i <= 10; i++)
    {
        Random rnd = new Random(i);
        TimeSpan ts = new TimeSpan(0,0,rnd.Next(10000));
        tsList.Add(ts);
    }
    //This is the line you will need
    tsList = tsList.OrderBy(x => x.TotalSeconds).ToList();
