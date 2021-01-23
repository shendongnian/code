	public class NRowsColumns
	{
		public int NRows { get; set; }
		public int NColumns { get; set; }
		public NRowsColumns(int nRows, int nColumns)
		{
			this.NRows = nRows;
			this.NColumns = nColumns;
		}
		public static implicit operator NRowsColumns(Point p)
		{
			return new NRowsColumns(p.X, p.Y);
		}
		public static implicit operator Point(NRowsColumns rowsColumns)
		{
			return new Point(rowsColumns.NRows, rowsColumns.NColumns);
		}
	}
