        public static IQueryable<MyEntity> WhereNameIs(
            this IQueryable<MyEntity> entities,
            string name)
        {
            return entities.Where(e => e.Name == name);
        }
        
