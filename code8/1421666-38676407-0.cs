    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
            return Equals((Pair<T1>) obj);
    }
    public override int GetHashCode()
    {
        unchecked
        {
            return (First*397) ^ EqualityComparer<T1>.Default.GetHashCode(Second);
        }
    }
