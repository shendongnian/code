    public static class Attributes
    {
        public static Attribute<int> Age = new Attribute<int>("age");
        public static Attribute<string> Name = new Attribute<string>("name");
    }
    public class Attribute<T>
    {
        public string Key { get; }
        public Attribute(string key)
        {
            Key = key;
        }
        ...
    }
