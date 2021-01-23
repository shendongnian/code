    public static class AirplaneQueryExtensions
    {
      public static IQueryable<Airplane> FilterByStatus(this IQueryable<Airplane> source, string statusMatch)
      {
        return source.Where(p => p.Status.Contains(statusMatch));
      }
    }
