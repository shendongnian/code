    class MyField<T>
    {
        public dynamic Value { get; private set; }
        
        public MyField(dynamic v) { Value = v; }
        public static implicit operator T(MyField field)
        {
            return (T)field.Value;
        }
    }
