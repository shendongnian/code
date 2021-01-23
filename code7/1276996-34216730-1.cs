    public class TestContractResolver : DefaultContractResolver
    {
        public string ExcludeProperties { get; set; }
        protected override IList<JsonProperty> CreateProperties(Type type,
                                               MemberSerialization memberSerialization)
        {
            if (!string.IsNullOrEmpty(ExcludeProperties))
                return base.CreateProperties(type, memberSerialization)
                            .Where(x => !ExcludeProperties.Split(',').Contains(x.PropertyName))
                            .ToList();
            return base.CreateProperties(type, memberSerialization);
        }
    }
