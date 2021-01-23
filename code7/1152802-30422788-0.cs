    public class ByteListComparer : IComparer<IList<byte>>
    {
        public int Compare(IList<byte> x, IList<byte> y)
        {
            int result;
            for(int index = 0; index<Min(x.Count, y.Count); index++)
            {
                result = x[index].CompareTo(y[index]);
                if (result != 0) return result;
            }
            return x.Count.CompareTo(y.Count);
        }
    }
