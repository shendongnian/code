    // Handle DragDrop on the second listview
	private void lbTwo_DragDrop(object sender, DragEventArgs e)
	{
		var targetlistview = (ListView) sender;
		if (e.Data.GetDataPresent(typeof(SelectedListViewItemCollection)))
		{
			foreach (ListViewItem current in (SelectedListViewItemCollection)e.Data.GetData(typeof(SelectedListViewItemCollection)))
			{
				current.Remove();
				targetlistview.Items.Add((ListViewItem)current);
			}
		}
	}
