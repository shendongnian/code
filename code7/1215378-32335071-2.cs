    public Bar FindRandomBarBroken(IEnumerable<Bar> bars, Random rng)
    {
        foreach (var bar in bars)
        {
            if (bar.ID == rng.Next(bar.Count) + 1)
            {
                return bar;
            }
        }
        throw new Exception("I didn't get lucky");
    }
