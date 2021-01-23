    public Bar FindRandomBarFixed(IEnumerable<Bar> bars, Random rng)
    {
        // Only generate a single number!
        int targetId = rng.Next(bar.Count) + 1;
        foreach (var bar in bars)
        {
            if (bar.ID == targetId)
            {
                return bar;
            }
        }
        throw new Exception("Odd - expected there to be a match...");
    }
