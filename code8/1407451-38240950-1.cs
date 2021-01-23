	private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		var item = sender as ListViewItem;
		if (item != null && item.IsSelected)
		{
			//Do your actions
		}
	}
