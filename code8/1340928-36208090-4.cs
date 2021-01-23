    [AttributeUsage(AttributeTargets.Property)]
    public sealed class UrlEncodeAttribute : System.Attribute
    {
        public String Name { get; private set; }
        public UrlEncodeAttribute(String name)
        {
            this.Name = name;
        }
    }
