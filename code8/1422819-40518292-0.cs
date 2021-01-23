    public class DateTimeComparer : IComparer<IConvertible>
    {
        public static readonly DateTimeComparer Instance = new DateTimeComparer();
        public int Compare(IConvertible x, IConvertible y)
        {
            var str1 = Convert.ToString(x, CultureInfo.InvariantCulture);
            var str2 = Convert.ToString(y, CultureInfo.InvariantCulture);
            return string.Compare(str1, str2, StringComparison.Ordinal);
        }
    }
