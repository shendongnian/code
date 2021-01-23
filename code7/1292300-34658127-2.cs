    public static IQueryable<Player> NotPerforming<T>(this IQueryable<Player> players) where T : Player
    {
        if (typeof(T) == typeof(Goalkeeper))
        {
            return players.OfType<Goalkeeper>().NotPerforming();
        }
        if (typeof(T) == typeof(Striker))
        {
            return players.OfType<Striker>().NotPerforming();
        }
        return null;
    }
    private static IQueryable<Goalkeeper> NotPerforming(this IQueryable<Goalkeeper> goalkeepers)
    {
        return goalkeepers.Where(g => g.Saves < goalkeepers.Average(x => x.Saves));
    }
    private static IQueryable<Striker> NotPerforming(this IQueryable<Striker> strikers)
    {
        return strikers.Where(g => g.Goals < strikers.Average(x => x.Goals));
    }
