    public static long GetDeterministicId(string m)
    {
        return (long) m.ToCharArray().Select((c, i) => Math.Pow(i, c%5)*Math.Max(Math.Sqrt(c), i)).Sum();
    }
    
