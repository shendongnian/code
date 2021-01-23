    for (int t = 1; t <= 12; t++)
    {
        int months = int.Parse(DateTime.Now.Month.ToString(t.ToString())); // <-- BUG
        Måneder.Add(months);
    }
