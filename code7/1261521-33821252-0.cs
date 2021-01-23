	public event RoutedEventHandler CloseClick;
	private void ButtonX_Click(object sender, RoutedEventArgs e)
	{
		if (CloseClick != null)
			CloseClick(sender, e);
	}
