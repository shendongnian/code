    private static Random _ran = new Random();
    public static DateTime RandomDateTime()
    {
        return
            DateTime.MinValue.Add(
                TimeSpan.FromTicks((long) (_ran.NextDouble()*DateTime.MaxValue.Ticks)));
    }
