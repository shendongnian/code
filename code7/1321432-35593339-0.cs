    class TypeWrapper
    {
        public object Value { get; set; }
        public string Type { get; set; }
    
        public static implicit operator TypeWrapper(long value)
        {
            return new TypeWrapper { Value = value, Type = typeof(long).FullName };
        }
    
        public static implicit operator long(TypeWrapper value)
        {
            return (long)value.Value;
        }
    
        public static implicit operator TypeWrapper(int value)
        {
            return new TypeWrapper { Value = value, Type = typeof(int).FullName };
        }
    
        public static implicit operator int(TypeWrapper value)
        {
            return (int)value.Value;
        }
    }
