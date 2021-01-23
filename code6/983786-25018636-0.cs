    public class ApiElementNameAttribute : Attribute
    {
        private readonly string _name;
        public string Name
        { get { return _name; } }
        public ApiElementNameAttribute(string name)
        {
            _name = name;
        }
    }
