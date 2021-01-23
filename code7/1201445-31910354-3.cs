    public class OrderDateComparer : IComparer<IOrderDate>
    {
        public int Compare(IOrderDate x, IOrderDate y)
        {
            return x.CreateDate.CompareTo(y.CreateDate);
        }
    }
