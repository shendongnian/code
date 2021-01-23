    public static class ContainerBuilderEnumerateAttributedTypes
    {
        #region Properties
        public static void EnumerateAttributedTypes<TAttribute>(this ContainerBuilder builder,
            Action<Type, TAttribute> action) where TAttribute : Attribute
        {
            var typesAndAttributes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.GetCustomAttributes(typeof(TAttribute), false).Length != 0)
                .Select(type => new { Type = type, Attribute = (TAttribute)type.GetCustomAttributes(typeof(TAttribute), false)[0] });
            foreach (var typeAndAtttribute in typesAndAttributes)
            {
                action(typeAndAtttribute.Type, typeAndAtttribute.Attribute);
            }
        }
        #endregion
    }
