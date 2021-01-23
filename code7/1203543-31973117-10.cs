    var users = context.Users.WhereIsNotDeleted(x => x.Id > 0).ToList();
    public static class Extension
    {
        public static IEnumerable<T> WhereIsNotDeleted<T>(this IQueryable<T> source,
            Expression<Func<T, bool>> predicate) where T : IDeletable
        {
            var query = source.AsExpandable().Where(x => !x.IsDeleted);
            return query.Where(predicate);
        }
    }
