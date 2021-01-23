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
            members.RemoveAll(x => !x.CanRead || !x.CanWrite);
            return members.Cast<MemberInfo>().ToList();
        }
    }
