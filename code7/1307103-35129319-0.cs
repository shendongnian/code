    public class IdEventComparer : IEqualityComparer<SampleObject>
    {
        public bool Equals(SampleObject x, SampleObject y)
        {
            if (object.ReferenceEquals(x, y)) 
                return true;
            if (x == null || y == null) 
                return false;
            if(x.Id != y.Id) 
                return false;
            if (x.Events == null && y.Events == null)
                return true;
            if (x.Events == null || y.Events == null)
                return false;
            return x.Events.SequenceEqual(y.Events);
        }
        public int GetHashCode(SampleObject obj)
        {
            if(obj == null) return 23;
            unchecked
            {
                int hash = 23;
                hash = (hash * 31) + obj.Id == null ? 31 : obj.Id.GetHashCode();
                if (obj.Events == null) return hash;
                foreach (string item in obj.Events)
                {
                    hash = (hash * 31) + (item == null ? 0 : item.GetHashCode());
                }
                return hash;
            }
        }
    }
