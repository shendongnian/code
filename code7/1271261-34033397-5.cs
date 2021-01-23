    public static DateTime RandomDateTime(DateTime min, DateTime max)
    {
        return
            DateTime.MinValue.Add(
                TimeSpan.FromTicks(min.Ticks + (long) (_ran.NextDouble()*(max.Ticks - min.Ticks))));
    }
