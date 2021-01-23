    public class PrefixedNumericStringComparer : IComparer<string>
    {
        public string Prefix { get; private set; }
        public PrefixedNumericStringComparer(string prefix)
        {
            if (prefix == null)
                throw new ArgumentNullException();
            this.Prefix = prefix;
        }
        #region IComparer<string> Members
        int? GetNumber(string value)
        {
            if (value == null)
                return null;
            if (value.StartsWith(Prefix))
            {
                var s = value.Substring(Prefix.Length);
                int iValue;
                if (int.TryParse(s, NumberStyles.None, NumberFormatInfo.InvariantInfo, out iValue))
                    return iValue;
                return null;
            }
            return null;
        }
        public int Compare(string x, string y)
        {
            var iX = GetNumber(x);
            var iY = GetNumber(y);
            if (iX == null && iY == null)
                return string.Compare(x, y, StringComparison.Ordinal);
            else if (iX == null)
                return 1;
            else if (iY == null)
                return -1;
            else return iX.Value.CompareTo(iY.Value);
        }
        #endregion
    }
