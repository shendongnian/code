    public class PropertyDescription
    {
        public string PropertyName { get; set; }
        public string Type { get; set; }
        public bool IsPrimitive { get; set; }
        public IEnumerable<PropertyDescription> Properties { get; set; }
    }
