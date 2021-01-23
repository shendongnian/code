    [AttributeUsage(AttributeTargets.Class)]
    public class IdPropertyAttribute : Attribute
    {
        public string IdProperty { get; private set; }
        public IdPropertyAttribute(string idProperty) { this.IdProperty = idProperty; }
    }
