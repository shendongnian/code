    public static class PlayerExtensions
    {
        public static IEnumerable<Player> SortByScore(this IEnumerable<Player> players)
        {
            return players.OrderByDescending(p => p.Score);
        }
    }
