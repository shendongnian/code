    public static class Extensions
    {
        public static IQueryable<Mammal> IncludeExtraEntities<Mammal,T>(this IQueryable<Mammal> query, T derivedType) where T :Mammal
        {
            if (derivedType is Dog)
                return query.Include("Tail");
            if (derivedType is Bat)
                return query.Include("Wing");
            return query;
        }
    }
