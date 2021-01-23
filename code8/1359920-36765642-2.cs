    public class CustomerContext : DbContext
    {
        private static IReadOnlyDictionary<Type, IReadOnlyCollection<PropertyInfo>> _ignoredProperties;
        /// Hold the ignored properties configured from fluent mapping
        public static IReadOnlyDictionary<Type, IReadOnlyCollection<PropertyInfo>> IgnoredProperties
        {
            get
            {
                return _ignoredProperties;
            }
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Ignore(customer => customer.Age);
    
            // Build ignored properties only if they are not                
            if (_ignoredProperties == null)
            {                
                var model = modelBuilder.Build(this.Database.Connection);                
                var mappedEntityTypes = new Dictionary<Type, IReadOnlyCollection<PropertyInfo>>();
                foreach (var entityType in model.ConceptualModel.EntityTypes)
                {
                    var type = Type.GetType(entityType.FullName);
                    var typeProperties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    var mappedProperties = entityType.DeclaredProperties.Select(t => t.Name)
                        .Union(entityType.NavigationProperties.Select(t => t.Name));
                    mappedEntityTypes.Add(type, new ReadOnlyCollection<PropertyInfo>(
                        typeProperties.Where(t => !mappedProperties.Contains(t.Name)).ToList()));
                }
                _ignoredProperties = new ReadOnlyDictionary<Type, IReadOnlyCollection<PropertyInfo>>(mappedEntityTypes);
            }
    
            base.OnModelCreating(modelBuilder);
        }
    
        public DbSet<Customer> Customers { get; set; }
    }
