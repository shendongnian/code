    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public sealed class DescriptionEntryAttribute : Attribute
    {
        public string Key { get; private set; }
        public string Value { get; private set; }
        public DescriptionEntryAttribute(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
