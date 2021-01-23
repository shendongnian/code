    public class CustomComparer : IComparer<string>, IComparer {
        #region IComparer<string> Members
        int? ExtractNumber(string str)
        {
            int index = str.LastIndexOf(',');
            if (index < 0)
                return null;
            var subStr = str.Substring(index+1);
            int result;
            if (int.TryParse(subStr, out result))
                return result;
            return null;
        }
        // Return x - y
        public int Compare(string x, string y)
        {
    #if false
            Given: f.e.
            [0] 23,24
            [1] 12,33
            [2] 37,11
            Arraylist.Sort should give back (sorted by the last number ascending):
            [0] 37,11
            [1] 23,24
            [2] 12,33
    #endif
            var xVal = ExtractNumber(x);
            var yVal = ExtractNumber(y);
            if (!xVal.HasValue && !yVal.HasValue)
                return x.CompareTo(y);
            else if (!xVal.HasValue)
                return 1;
            else if (!yVal.HasValue)
                return -1;
            int cmp = xVal.Value.CompareTo(yVal.Value);
            if (cmp != 0)
                return cmp;
            return x.CompareTo(y);
        }
        #endregion
        #region IComparer Members
        public int Compare(object x, object y)
        {
            if (object.ReferenceEquals(x, y))
                return 0;
            string xStr = x as string;
            string yStr = y as string;
            if (xStr == null && yStr == null)
                return 0;  // NO IDEA
            else if (xStr == null)
                return 1;
            else if (yStr == null)
                return -1;
            else return Compare(xStr, yStr);
        }
        #endregion
    }
