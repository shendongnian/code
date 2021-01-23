    public struct Key : IComparable<Key> 
    {
        public int CompareTo(Key other)
        {
            return Comparer.Default<string>.Compare(otherSortingVariable, other.otherSortingVariable);
        }
    }
