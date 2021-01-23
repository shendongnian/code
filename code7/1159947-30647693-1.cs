    public sealed class Range<T> : IEquatable<Range<T>>
        where T : IComparable<T>, IEquatable<T>
    {
        ...
        public override int GetHashCode()
        {
            int hash = 23;
            hash = hash * 31 + EqualityComparer.Default<T>.GetHashCode(Minimum);
            hash = hash * 31 + EqualityComparer.Default<T>.GetHashCode(Maximum);
            return hash;
        } 
        public override bool Equals(object other)
        {
            return Equals(other as Range<T>);
        }
        public bool Equals(Range<T> other)
        {
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            return EqualityComparer<T>.Default.Equals(Minimum, other.Minimum) &&
                   EqualityComparer<T>.Default.Equals(Maximum, other.Maximum); 
        }
    }
