		Parallel.For(0, ColumnCount, i =>
			{
				for (int j = 0; j < RowCount; ++j)
				{
					WorldPosition[i, j].X = (i - HalfColumnCount) * ColumnSize + ColumnSize / 2;
					WorldPosition[i, j].Y = (j - HalfRowCount) * RowSize + RowSize / 2;
				}
			});
