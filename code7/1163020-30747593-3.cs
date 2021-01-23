    public class A:IComparable<A>
    {
        public string Name { get; set; }
        public Dictionary<int, List<int>> Years { get; set; }
        private int complists(List<int> a, List<int> b)
        {
            var iret = (from i in Enumerable.Range(0, Math.Min(a.Count, b.Count))
                         where a[i].CompareTo(b[i]) != 0
                         select a[i] > b[i] ? 1 : -1).FirstOrDefault();
            return iret;
        }
        public int CompareTo(A other)
        {
            var mykeys = this.Years.Keys.ToList();
            var otherkeys = other.Years.Keys.ToList();
            var iret = (from i in Enumerable.Range(0, Math.Min(mykeys.Count, otherkeys.Count))
                         let yearDiff = mykeys[i].CompareTo(otherkeys[i])
                         let monthDiff = complists(this.Years[mykeys[0]], other.Years[otherkeys[0]])
                         where yearDiff != 0 || monthDiff != 0
                         select yearDiff != 0 ? yearDiff : monthDiff).FirstOrDefault();
            return iret != 0 ? iret : mykeys.Count > otherkeys.Count ? 1 : mykeys.Count < otherkeys.Count ? -1 : 0;
        }    }
