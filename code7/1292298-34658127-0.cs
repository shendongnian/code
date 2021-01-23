    public static IQueryable<Player> NotPerforming(this IQueryable<Player> players)
    {
        var notPerformingGoalKeepers = players.NotPerformingGoalkeepers();
        var notPerformingStrikers = players.NotPerformingStrikers();
        return notPerformingGoalKeepers.Cast<Player>()
            .Concat(notPerformingStrikers);
    }
    public static IQueryable<Goalkeeper> NotPerformingGoalkeepers(this IQueryable<Player> players)
    {
        var goalkeepers = players.OfType<Goalkeeper>();
        return goalkeepers.Where(g => g.Saves < goalkeepers.Average(x => x.Saves));
    }
    public static IQueryable<Striker> NotPerformingStrikers(this IQueryable<Player> players)
    {
        var strikers = players.OfType<Striker>();
        return strikers.Where(g => g.Goals < strikers.Average(x => x.Goals));
    }
