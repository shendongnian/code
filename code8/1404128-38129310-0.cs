    public class Rule
    {
        private StringComparer _stringComparer;
        public Rule(string name, RuleType type, StringComparer stringComparer = null)
        {
            if (name == null)
                throw new ArgumentNullException("name", "name is null.");
            if (type == null)
                throw new ArgumentNullException("type", "type is null.");
            if (stringComparer == null)
                _stringComparer = StringComparer.CurrentCulture;
            else
                _stringComparer = stringComparer;
            Name = name;
            Type = type;
        }
        public RuleType Type { get; private set; }
        public string Name { get; private set; }
        public override bool Equals(object obj)
        {
            var rhs = obj as Rule;
            if (rhs == null)
                return false;
            var namesEqual = _stringComparer.Equals(Name, rhs.Name);
            var typesEqual = Type.Equals(rhs.Type);
            if (namesEqual && typesEqual)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + Name.GetHashCode();
                hash = hash * 23 + Type.GetHashCode();
                return hash;
            }
        }
    }
