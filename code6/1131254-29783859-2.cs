    public static PScore GetScore(IEnumerable<PStat> rs)
    {
        return new PScore
        {
            Kills = rs.Select(item => item.Kill).Sum(kill =>
            {
                if (kill <= 5) return 1;
                else if (kill <= 10) return 2;
                else if (kill <= 15) return 3;
                else return 4;
            });
        };
    }
