    public class MultiFieldComparer : IEquatable<IEnumerable<object>>, IEqualityComparer<IEnumerable<object>>
    {
        private IEnumerable<object> objects;
        public MultiFieldComparer(IEnumerable<object> objects)
        {
            this.objects = objects;
        }
        public bool Equals(IEnumerable<object> x, IEnumerable<object> y)
        {
            return x.SequenceEqual(y);
        }
        public int GetHashCode(IEnumerable<object> objects)
        {
            unchecked
            {
                int hash = 17;
                foreach (object obj in objects)
                    hash = hash * 23 + (obj == null ? 0 : obj.GetHashCode());
                return hash;
            }
        }
        public override int GetHashCode()
        {
            return GetHashCode(this.objects);
        }
        public override bool Equals(object obj)
        {
            MultiFieldComparer other = obj as MultiFieldComparer;
            if (other == null) return false;
            return this.Equals(this.objects, other.objects);
        }
        public bool Equals(IEnumerable<object> other)
        {
            return this.Equals(this.objects, other);
        }
    }
