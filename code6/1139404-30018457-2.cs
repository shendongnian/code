    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class LocalizableDisplayNameAttributeI : DisplayNameAttribute
    {
        private static readonly MethodInfo _getMethod = typeof(LocalizableDisplayNameAttributeI)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .First(x => x.IsGenericMethod && x.Name == "Get");
        public LocalizableDisplayNameAttributeI(string displayName) : base(displayName) { }
        public override string DisplayName
        {
            get
            {
                return global::Res.Translate(base.DisplayName);
            }
        }
        public static string Get(Type entityType)
        {
            return (string)_getMethod.MakeGenericMethod(entityType).Invoke(null, null);
        }
        public static string Get<TEntity>()
        {
            var attrib = typeof(TEntity)
                .GetCustomAttributes(typeof(LocalizableDisplayNameAttributeI), true)
                .FirstOrDefault() as LocalizableDisplayNameAttributeI;
            return attrib != null ? attrib.DisplayName : typeof(TEntity).Name;
        }
    }
