	private void DataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		DataGrid dg = sender as DataGrid;
		if (btnClicked)
		{
			if (e.RemovedItems.Count == 0)
			{
				dg.SelectionChanged -= new SelectionChangedEventHandler(DataGrid_OnSelectionChanged);
				var op1 = dg.Dispatcher.BeginInvoke(new Action(() => dg.SelectedIndex = -1),
					System.Windows.Threading.DispatcherPriority.ContextIdle);
				op1.Completed += new EventHandler((s, ea) => dg.SelectionChanged +=
					new SelectionChangedEventHandler(DataGrid_OnSelectionChanged));
			}
			else
			{
				dg.SelectionChanged -= new SelectionChangedEventHandler(DataGrid_OnSelectionChanged);
				var op2 = dg.Dispatcher.BeginInvoke(new Action(() => dg.SelectedItem = e.RemovedItems[0]),
					System.Windows.Threading.DispatcherPriority.ContextIdle);
				op2.Completed += new EventHandler((s, ea) => dg.SelectionChanged +=
					new SelectionChangedEventHandler(DataGrid_OnSelectionChanged));
			}
			btnClicked = false;
			return;
		}
    }
