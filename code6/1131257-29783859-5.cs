    public static PScore GetScore(IEnumerable<PStat> rs)
    {
        return new PScore
        {
            Kills = rs.Select(item => item.Kill)
                .Sum(kill => Math.Max(1, Math.Min((kill + 4) / 5, 4)));
        };
    }
