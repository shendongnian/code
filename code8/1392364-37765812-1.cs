    [JsonObjectContractModifier(typeof(TestContractModifier))]
    public class Test
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
    }
    class TestContractModifier : JsonObjectContractModifier
    {
        class EmptyValueProvider : IValueProvider
        {
            // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
            static EmptyValueProvider() { }
            internal static readonly EmptyValueProvider Instance = new EmptyValueProvider();
            #region IValueProvider Members
            public object GetValue(object target)
            {
                var test = target as Test;
                if (test == null)
                    return null;
                return test.A == null && test.B == null && test.C == null;
            }
            public void SetValue(object target, object value)
            {
                var property = target as Test;
                if (property == null)
                    return;
                if (value != null && value.GetType() == typeof(bool) && (bool)value == true)
                {
                    property.A = property.B = property.C = null;
                }
            }
            #endregion
        }
        public override void ModifyContract(Type objectType, JsonObjectContract contract)
        {
            var jsonProperty = new JsonProperty
            {
                PropertyName = "isEmpty",
                UnderlyingName = "isEmpty",
                PropertyType = typeof(bool?),
                NullValueHandling = NullValueHandling.Ignore,
                Readable = true,
                Writable = true,
                DeclaringType = typeof(Test),
                ValueProvider = EmptyValueProvider.Instance,
            };
            contract.Properties.Add(jsonProperty);
        }
    }
