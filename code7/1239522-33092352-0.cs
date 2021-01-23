    public struct CaseInsensitiveString
    {
        private readonly string _s;
        public CaseInsensitiveString(string s)
        {
            _s = s.ToLowerInvariant();
        }
        public static implicit operator CaseInsensitiveString(string d)
        {
            return new CaseInsensitiveString(d);
        }
        public override bool Equals(object obj)
        {
            return obj is CaseInsensitiveString && this == (CaseInsensitiveString)obj;
        }
        public override int GetHashCode()
        {
            return _s.GetHashCode();
        }
        public static bool operator ==(CaseInsensitiveString x, CaseInsensitiveString y)
        {
            return x._s == y._s;
        }
        public static bool operator !=(CaseInsensitiveString x, CaseInsensitiveString y)
        {
            return !(x == y);
        }
    }
