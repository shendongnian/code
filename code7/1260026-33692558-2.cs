    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
    public class UpdateEntity : BaseEntity
    {
        public DateTime Updated { get; set; }
    }
    public class Entity1 : BaseEntity
    {
        public string Name { get; set; }
    }
    public class Entity2 : UpdateEntity
    {
        public string Name { get; set; }
    }
    public abstract class BaseEntityTypeConfiguration<T> : EntityTypeConfiguration<T>
        where T : BaseEntity
    {
        public BaseEntityTypeConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
    public abstract class UpdateEntityTypeConfiguration<T> : EntityTypeConfiguration<T>
        where T : UpdateEntity
    {
        public UpdateEntityTypeConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
    public class Entity1Configuration : BaseEntityTypeConfiguration<Entity1>
    {
        public Entity1Configuration()
            : base()
        {
            Property(x => x.Name).HasMaxLength(100);
        }
    }
    public class Entity2Configuration : UpdateEntityTypeConfiguration<Entity2>
    {
        public Entity2Configuration()
            : base()
        {
            Property(x => x.Name).HasMaxLength(100);
        }
    }
    public class MyDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = from type in Assembly.GetExecutingAssembly().GetTypes()
                                  where !string.IsNullOrEmpty(type.Namespace) &&
                                        type.BaseType != null &&
                                        type.BaseType.IsGenericType
                                  let genericType = type.BaseType.GetGenericTypeDefinition()
                                  where genericType == typeof(BaseEntityTypeConfiguration<>) || genericType == typeof(UpdateEntityTypeConfiguration<>)
                                  let genericArgument = type.BaseType.GetGenericArguments().FirstOrDefault()
                                  where genericArgument != null && genericArgument.BaseType != null &&
                                  (genericArgument.BaseType == typeof(BaseEntity) || genericArgument.BaseType == typeof(UpdateEntity))
                                  select type;
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
