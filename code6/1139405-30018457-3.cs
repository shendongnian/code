    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class LocalizableDisplayNameAttributeI : DisplayNameAttribute
    {
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
            var attrib = entityType
                .GetCustomAttributes(typeof(LocalizableDisplayNameAttributeI), true)
                .FirstOrDefault() as LocalizableDisplayNameAttributeI;
            return attrib != null ? attrib.DisplayName : entityType.Name;
        }
        public static string Get<TEntity>()
        {
            return Get(typeof(TEntity));
        }
    }
