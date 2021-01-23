    private void lbOne_MouseMove(object sender, MouseEventArgs e)
	{
        /* ... */
		sourcelistview = (ListView)sender;
		foreach (object selItem in _selItems)
		{
			if (!sourcelistview.SelectedItems.Contains(selItem))
				sourcelistview.SelectedItems.Add(selItem);
		}
        /* ... */
    }
