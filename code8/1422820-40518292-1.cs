    public class DateTimeComparer : IComparer<IConvertible>
    {
        public static readonly DateTimeComparer Instance = new DateTimeComparer();
        public int Compare(IConvertible x, IConvertible y)
        {
            var dateTime1 = Convert.ToDateTime(x);
            var dateTime2 = Convert.ToDateTime(y);
            return dateTime1.CompareTo(dateTime2);
        }
    }
