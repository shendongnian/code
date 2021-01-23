    public class Comp : IComparer<Bill>
    {
        public int Compare(Bill x, Bill y)
        {
           // remember to handle null values first (x or y or both are nulls)
           return x.Date.CompareTo(y.Date);
        }
    }
