    public class EntityHelper<Entity> where Entity :class
    {
        private DbContext _context;
        public EntityHelper(DbContext context)
        {
            _context = context;
        }
        public string[] FindPrimaryKeyNames()
        {
            var objectSet = ((IObjectContextAdapter)_context).ObjectContext.CreateObjectSet<Entity>();
            var keyNames = objectSet.EntitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();
            return keyNames;
        }
        public Type[] FindPrimaryKeyTypes()
        {
            var keyNames = FindPrimaryKeyNames();
            var types = keyNames.Select(keyName => typeof(Entity).GetProperty(keyName).PropertyType).ToArray();
            return types;
        }
        public object[] FindPrimaryKeyDefaultValues()
        {
            var types = FindPrimaryKeyTypes();
            var defaultValues = types.Select(type => type.IsValueType ? Activator.CreateInstance(type) : null).ToArray();
            return defaultValues;
        }
    }
