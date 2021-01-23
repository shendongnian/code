	// Changes beeing made to the entire row in this case
	private void DgModules_LoadingRow(object sender, DataGridRowEventArgs e)
	{
		DataGridRow gridRow = e.Row;
		DataRow row = (gridRow.DataContext as DataRowView).Row;
		switch (row.RowState)
		{
			case DataRowState.Added:
				gridRow.Background = new SolidColorBrush(Colors.Green);
				break;
			case DataRowState.Modified:
				gridRow.Background = new SolidColorBrush(Colors.Yellow);
				break;
			case DataRowState.Deleted:
				gridRow.Background = new SolidColorBrush(Colors.Red);
				break;
		}
	}
