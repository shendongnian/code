    public class A:IComparable<A>
    {
        public string Name { get; set; }
        public Dictionary<int, List<int>> Years { get; set; }
        private int complists(List<int> a, List<int> b)
        {
            return (from x in a
                    from y in b
                    where x != y
                    select x < y ? -1 : 1).FirstOrDefault();
        }
        public int CompareTo(A other)
        {
            int ret = (from y in this.Years
                       from x in other.Years
                       let yearDiff = y.Key.CompareTo(x.Key)
                       let monthDiff = complists(y.Value, x.Value)
                       where yearDiff != 0 || monthDiff != 0
                       select yearDiff != 0 ? yearDiff : monthDiff).FirstOrDefault();
            return ret;
        }
    }
