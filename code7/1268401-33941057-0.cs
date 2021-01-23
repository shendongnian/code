    class MyDbContext : DbContext {
        public DbSet<ModelA> A { get; set; }
        public DbSet<ModelB> B { get; set; }
        public IQueryable<dynamic> GetByName_SwitchTest(string name) {
            switch (name) {
                case "A": return A;
                case "B": return B;
            }
        }
        public IQueryable<dynamic> GetByName_ReflectionTest(string fullname)
        {
            Type targetType = Type.GetType(fullname);
            var model = GetType()
                .GetRuntimeProperties()
                .Where(o => 
                    o.PropertyType.IsGenericType &&
                    o.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                    o.PropertyType.GenericTypeArguments.Contains(targetType))
                .FirstOrDefault();
            if (null != model)
                return (IQueryable<dynamic>)model.GetValue(this);
            return null;
        }
    }
