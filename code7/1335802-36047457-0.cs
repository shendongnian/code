    public class PolicyNumber : IComparable
    {
        private readonly string _number;
        public PolicyNumber(string number)
        {
            _number = number;
        }
        public int CompareTo(object obj)
        {
            var other = obj as PolicyNumber;
            if (other == null) return 0;
            return _number.StartsWith("CA") ^ other._number.StartsWith("CA")
                ? (_number.StartsWith("CA") ? -1 : 1)
                : string.Compare(_number, other._number, StringComparison.Ordinal);
        }
        public override string ToString()
        {
            return _number;
        }
        public override bool Equals(object obj)
        {
            var other = obj as PolicyNumber;
            return other != null && string.Equals(_number, other._number);
        }
        protected bool Equals(PolicyNumber other)
        {
            return string.Equals(_number, other._number);
        }
        public override int GetHashCode()
        {
            return (_number != null ? _number.GetHashCode() : 0);
        }
    }
