    // Handle DragDrop on the second listview
	private void lbTwo_DragDrop(object sender, DragEventArgs e)
	{
		var targetlistview = (ListView) sender;
		if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
		{
			foreach (ListViewItem current in (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection)))
			{
				current.Remove();
				targetlistview.Items.Add((ListViewItem)current);
			}
		}
	}
