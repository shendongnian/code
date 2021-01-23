    public class MyContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            var methodInfo = GetType().GetMethod("MapInheritedProperties");
            var type = typeof(MainObj);
            foreach (var descendantType in type.Assembly.GetTypes().Where(t => t.IsAssignableFrom(type)))
            {
                var mapInheritedProperties = methodInfo.MakeGenericMethod(descendantType);
                mapInheritedProperties.Invoke(null, new object[] { modelBuilder });
            }
            //base.OnModelCreating(modelBuilder); you dont need this line, it does nothing
        }
        private static void MapInheritedProperties<T>(DbModelBuilder modelBuilder) where T : class
        {
            modelBuilder.Entity<T>().Map(m => { m.MapInheritedProperties(); });
        }
    }
