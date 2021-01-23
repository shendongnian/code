    public class ReportsParameter<T>
    {
        public ReportsParameter(string name, T value = default(T))
        {
            _name = name; _value = value;
        }
        private readonly string _name;
        public string Name 
        { get { return _name; } }
        
        private readonly T _value;
        public T Value 
        { get { return _value; } }
    }
