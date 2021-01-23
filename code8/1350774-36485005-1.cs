    class IP_RangeComparer : IEqualityComparer<IP_Range>
    {
        public bool Equals(IP_Range r1, IP_Range r2)
        {
            return (r1.MinIP == r2.MinIP && r1.MaxIP == r2.MaxIP);
        }
        public int GetHashCode(IP_Range r)
        {
            return r.MinIP.GetHashCode();
        }
    }
