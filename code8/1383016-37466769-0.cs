    struct ConnectionString : IEquatable<ConnectionString>
    {
        readonly string _value;
        public string Value { get { return _value; } }
        public ConnectionString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(value);
            }
            _value = value;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj is ConnectionString && Equals((ConnectionString)obj));
        }
        public bool Equals(ConnectionString other)
        {
            return this == other;
        }
        public static bool operator ==(ConnectionString left, ConnectionString right)
        {
            return left._value == right._value;
        }
        public static bool operator !=(ConnectionString left, ConnectionString right)
        {
            return left._value != right._value;
        }
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
        public override string ToString()
        {
            return _value;
        }
        public static implicit operator ConnectionString(string value)
        {
            return new ConnectionString(value);
        }
        public static explicit operator string(ConnectionString value)
        {
            return value._value;
        }
    }
