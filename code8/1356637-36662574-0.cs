	public class Layout : IEquatable<Layout>
	{
		public int RowCount { get; }
		public int ColumnCount { get;  }
		public double Ratio { get; }
		public Layout(int rowCount, int columnCount)
		{
			RowCount = rowCount;
			ColumnCount = columnCount;
			Ratio = (float)rowCount/columnCount;
		}
	}
