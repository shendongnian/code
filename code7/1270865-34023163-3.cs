    public static class Extensions
    {
        public static IQueryable<Dog> IncludeExtraEntities<Dog>(this IQueryable<Dog> query) where Dog : Mammal
        {
                return query.Include("Tail");
        }
        public static IQueryable<Bat> IncludeExtraEntities<Bat>(this IQueryable<Bat> query) where Bat: Mammal
        {
                return query.Include("Wing");
        }
    }
