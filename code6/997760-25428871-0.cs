    public static class SyncExtension
    {
        public static void SyncData<T>(
            this IDbSet<T> source, 
            string[] names, 
            Expression<Func<T, string>> name, 
            Func<string, T> creator) where T : class
        {
            var columnName = ((MemberExpression)name.Body).Member.Name;
            var removePredicate = string.Format("!{0}.Contains(@0)", columnName);
            var toRemove = source.Where(removePredicate, names).ToArray();
            foreach (var item in toRemove)
                source.Remove(item);
            var addPredicate = string.Format("{0} = @0", columnName);
            var toCreate = names.Where(x => 
                !source.Where(addPredicate, x).Any()).ToArray();
            foreach (var item in toCreate)
                source.Add(creator(item));
        }
    }
