    public override int GetHashCode()
    {
        unchecked
        {
            return (First*397) ^ EqualityComparer<T1>.Default.GetHashCode(Second);
        }
    }
