    public static class SortHelper
    {
        public static IOrderedQueryable<Log> SortFromCommand(this IQueryable<Log> entities, LogSortOrder sortOrder)
        {
            IOrderedQueryable<Log> ordered;
            switch (sortOrder)
            {
                case LogSortOrder.LevelAsc:
                    ordered = entities.OrderBy(l => l.Level);
                    break;
                case LogSortOrder.LevelDesc:
                    ordered = entities.OrderByDescending( l => l.Level );
                    break;
                case LogSortOrder.MessageAsc:
                    ordered = entities.OrderBy( l => l.Message );
                    break;
                case LogSortOrder.MessageDesc:
                    ordered = entities.OrderByDescending( l => l.Message );
                    break;
                case LogSortOrder.DateTimeAsc:
                    ordered = entities.OrderBy( l => l.Date );
                    break;
                default:
                    ordered = entities.OrderByDescending( l => l.Date );
                    break;
            }
            return ordered;
        }
    }
