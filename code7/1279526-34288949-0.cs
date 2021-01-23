    public class CustomType
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public Dictionary<string, string> AsJsonProperty()
        {
            return new Dictionary<string, string>
            {
                {Type, Value}
            };
        }
    }
    class Class1
    {
        public string ToJson(IEnumerable<IEnumerable<CustomType>> customTypes)
        {
            var asJsonFriendly = customTypes.Select(x => x.Select(y => y.AsJsonProperty()));
            return JsonConvert.SerializeObject(asJsonFriendly);
        }
    }
