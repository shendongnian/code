    public static class NewtonsoftDefaultSettings
    {
        public static JsonSerializerSettings CreateRelease()
        {
            return Create(Formatting.None);
        }
        public static JsonSerializerSettings CreateDebug()
        {
            return Create(Formatting.Indented);
        }
        private static JsonSerializerSettings Create(Formatting formatting)
        {
            return new JsonSerializerSettings
            {
                Formatting = formatting,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new MyContractResolver()
            };
        }
    }
    internal class MyContractResolver : DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            var members = base.GetSerializableMembers(objectType).Cast<PropertyInfo>().ToList();
            members.RemoveAll(x =>!x.PropertyType.IsSimpleType());
            return members.Cast<MemberInfo>().ToList();
        }
    }
    public static class TypeExt
    {
        public static bool IsSimpleType(this Type type)
        {
            type = type.GetNullableUnderlyingType();
            return type.IsPrimitive || type == typeof(string) || type == typeof(decimal) || type == typeof(Guid)
                || type == typeof(DateTime) || type == typeof(DateTimeOffset) || type == typeof(TimeSpan);
        }
        public static Type GetNullableUnderlyingType(this Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return Nullable.GetUnderlyingType(type);
            return type;
        }
    }
