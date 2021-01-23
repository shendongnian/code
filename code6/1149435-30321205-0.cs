    public class StringEnum<TChildType> where TChildType : StringEnum<TChildType>, new()
    {
        private static readonly HashSet<string> members;
        private static readonly List<string> sortedmembers;
        private string _value;
        public string Value
        {
            get { return _value; }
            protected set
            {
                if (!Contains(value))
                {
                    throw new ArgumentException(String.Format("Value '{0}' wasnt found in Enum", value));
                }
                _value = value;
            }
        }
        public static IEnumerable<string> Values
        {
            get { return sortedmembers; }
        }
        public static bool Contains(string value)
        {
            return members.Contains(value);
        }
        static StringEnum()
        {
            sortedmembers = Service.GetGenericConstProperties<string>(typeof(TChildType)); // .ToList() if necessary
            members = new HashSet<string>(sortedmembers);
            if (members.Count < 2) throw new Exception("Fill Enum!");
        }
        public static implicit operator StringEnum<TChildType>(string str)
        {
            return new TChildType { Value = str };
        }
        public static implicit operator string(StringEnum<TChildType> source)
        {
            return source != null ? source.Value : null;
        }
        public static StringEnum<TChildType> Parse(string value)
        {
            return (StringEnum<TChildType>)value;
        }
        public override string ToString()
        {
            return (string)this;
        }
        public override int GetHashCode()
        {
            return StringComparer.Ordinal.GetHashCode(Value);
        }
        public override bool Equals(object obj)
        {
            StringEnum<TChildType> value = obj as StringEnum<TChildType>;
            if (object.ReferenceEquals(value, null))
            {
                return false;
            }
            return StringComparer.Ordinal.Equals(Value, value.Value);
        }
    }
