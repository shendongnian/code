    public class MyApiNameAttribute : Attribute
    {
        private readonly string _name;
        public string Name
        { get { return _name; } }
        public MyApiNameAttribute(string name)
        { _name = name; }
    }
