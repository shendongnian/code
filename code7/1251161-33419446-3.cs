    public abstract class ValueType
    {
        public enum Types { Decimal, String, Boolean };
        public abstract object Data { get; }
        public abstract Types Type { get; }
        private ValueType() {}
        protected class TypedValueType<T> : ValueType
        {
            private Types type;
            public TypedValueType(T value, Types type) : base()
            {
                this.Value  = value;
                this.type   = type;
            }
            public override object Data { get { return this.Value; } }
            public override Types Type { get { return this.type; } }
            public T Value { get; private set; }
            public override string ToString()
            {
                return this.Value.ToString();
            }
        }
        public static implicit operator ValueType(decimal value) { return new TypedValueType<decimal>(value, Types.Decimal); }
        public static implicit operator ValueType(double value) { return new TypedValueType<decimal>((decimal)value, Types.Decimal); }
        public static implicit operator ValueType(int value) { return new TypedValueType<decimal>((decimal)value, Types.Decimal); }
        public static implicit operator ValueType(string value) { return new TypedValueType<string>(value, Types.String); }
        public static implicit operator ValueType(bool value) { return new TypedValueType<bool>(value, Types.Boolean); }
    }
