    public static class EntityExtensions
    {
        public static bool CanDelete(this object entity)
        {
            return entity.GetType().GetProperties()
                .Where(x => x.IsDefined(typeof(MustBeEmptyToDeleteAttribute)))
                .Select(x => x.GetValue(entity))
                .OfType<IEnumerable<object>>()
                .All(x => !x.Any());
        }
    }
