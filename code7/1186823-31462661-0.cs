    public interface ICompareAsHtml : IComparable
    {
        int compareAsHtml(object obj);
    }
    class CompareAsHtml : ICompareAsHtml
    {
        public int CompareTo(object obj)
        {
            return compareAsHtml(obj);
        }
        public int compareAsHtml(object obj)
        {
            //do the core comparison here and return
        }
    }
