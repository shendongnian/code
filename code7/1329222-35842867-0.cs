    public class TypeMapper
    {
        public readonly Type Type;
        object _value;
        public object Value
        {
            get { return _value; }
            set
            {
                // If Type is null, any type is permissable. 
                // Else check that the input value's type matches Type.
                if (Type == null || value.GetType().Equals(Type))
                    _value = value;
                else
                    throw new Exception("Invalid type.");
            }
        }
    
        static Dictionary<string, Type> _types = new Dictionary<string, Type>()
        {
            { "string", typeof(string) },
            { "int", typeof(int) },
            { "double", typeof(double) },
        };
    
        public TypeMapper(string type)
        {
            // If 'type' is not described in _types then 'Type' is null
            // - any type is permissable.
            _types.TryGetValue(type, out Type);
        }
    }
