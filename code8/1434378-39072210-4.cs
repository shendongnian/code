    public class StringOrInt
    {
        private object value;
        public ValueType Type { get; set; }
    
        public static implicit operator StringOrInt(string value)
        {
            return new StringOrInt()
            {
                value = value,
                Type = ValueType.String
            };
        }
        public static implicit operator StringOrInt(int value)
        {
            return new StringOrInt()
            {
                value = value,
                Type = ValueType.Int
            };
        }
        public static implicit operator int(StringOrInt obj)
        {
            return (int)obj.value;
        }
        public static implicit operator string(StringOrInt obj)
        {
            return (string)obj.value;
        } 
    }
    public enum ValueType
    {
        String,
        Int
    }
