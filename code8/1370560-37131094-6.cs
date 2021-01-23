    public class DisplayAttributeBasedObjectDataProvider : ObjectDataProvider
    {
        public object GetEnumValues(Enum enumObj)
        {
            var attribute = enumObj.GetType().GetRuntimeField(enumObj.ToString()).
                GetCustomAttributes(typeof(DisplayAttribute), false).
                SingleOrDefault() as DisplayAttribute;
            return attribute == null ? enumObj.ToString() : attribute.Description;
        }
        public List<object> GetShortListOfApplicationGestures(Type type)
        {
            var shortListOfApplicationGestures = Enum.GetValues(type).OfType<Enum>().Select(GetEnumValues).ToList();
            return
                shortListOfApplicationGestures;
        }
    }
