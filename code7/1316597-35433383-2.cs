    public class TestComparer : IComparer<test>
    {
        bool isAscending;
        public TestComparer(bool isAscendingOrder)
        {
            isAscending = isAscendingOrder;
        }
        int IComparer<test>.Compare(test a, test b)
        {
            int c1 = IntFromStr(a.feet);
            int c2 = IntFromStr(b.feet);
            int res;
            res = (c1 > c2) ? 1 : (c1 < c2) ? -1 : 0;
            return isAscending ? res : -res;
        }
        int IntFromStr(string s)
        {
            int result;
            return (int.TryParse(s.Replace("'", ""), out result)) ? result : int.MaxValue;
        }
    }
