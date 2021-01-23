    public class CellComparer : IEqualityComparer<Cell>
    {
        public bool Equals(Cell x, Cell y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            if (x.Column == y.Column && x.Row == y.Row) return true;
            return false;
        }
        public int GetHashCode(Cell cell)
        {
            int hCode = cell.Column ^ cell.Row;
            return hCode.GetHashCode();
        }
    }
