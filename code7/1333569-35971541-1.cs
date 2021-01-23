    public class CellComparer : IEqualityComparer<Cell>
    {
        public bool Equals(Cell x, Cell y)
        {
            if (ReferenceEquals(x, null)) return ReferenceEquals(y, null);
            if (ReferenceEquals(y, null)) return false;
            return x.PossibleValues.SequenceEqual(y.PossibleValues);
        }
        public int GetHashCode(Cell obj)
        {
            if (obj == null) return 0;
            unchecked
            {
                int hash = 1;
                foreach (int h in obj.PossibleValues.Select(v => v?.GetHashCode() ?? 0))
                    hash = (hash * 397) ^ h;
                return hash;
            }
        }
    }
