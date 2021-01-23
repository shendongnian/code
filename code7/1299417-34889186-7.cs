    public class ColumnComparer : IEqualityComparer<Column>
    {
        public bool Equals(Column x, Column y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;
            return x.Name == y.Name;
        }
        
        public int GetHashCode(Column column)
        {
            if (Object.ReferenceEquals(column, null)) return 0;
            return column.Name.GetHashCode();
        }
    }
