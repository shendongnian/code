    internal class MyConverter : CustomCreationConverter<IDictionary<CustomClass, List<String>>>
    {
        public override IDictionary<CustomClass, List<String>> Create(Type objectType)
        {
            return new Dictionary<CustomClass, List<String>>();
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (object) || base.CanConvert(objectType);
        }
    }
