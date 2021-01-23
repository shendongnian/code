    private List<object> _selItems = new List<object>();	
    private void lbOne_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		startPoint = e.GetPosition(null);
		_selItems.Clear();
		_selItems.AddRange(((ListView)sender).SelectedItems.Cast<object>());
	}
