    class MyDbContext : DbContext {
        public DbSet<ModelA> A { get; set; }
        public DbSet<ModelB> B { get; set; }
        // In my case, this method help me to know the next action I need to do
		// The switch/case option is not pretty but might have better performance 
		// than Reflection. Anyhow, this is one's choice.
        public bool HasRecord_SwitchTest(string name) {
            switch (name) {
                case "A": return A.AsNoTracking().Any(o => o.Id == id);
                case "B": return B.AsNoTracking().Any(o => o.Id == id);
            }
            return false;
        }
        // In my case, this method help me to know the next action I need to do
        public bool HasRecord_ReflectionTest(string fullname)
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
                return (bool)model.GetValue(this).AsNoTracking().Any(o => o.Id == id);
            return false;
        }
		// Update and save immediately - simplified for example
        public async Task<bool> UpdateDynamic(object content)
        {
            EntityEntry entry = Update(content, GraphBehavior.SingleObject);
            return 1 == await SaveChangesAsync(true);
        }
		// Insert and save immediately - simplified for example
        public async Task<bool> InsertDynamic(object content)
        {
            EntityEntry entry = Add(content, GraphBehavior.SingleObject);
            return 1 == await SaveChangesAsync(true);
        }
    }
