    private void dataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			var header = new List<string>() { "asdasd" };
			foreach (string headerItem in header)
			{
				DataGridTextColumn head = new DataGridTextColumn { Header = headerItem };
				dataGrid.Columns.Add(head);
			}
		}
