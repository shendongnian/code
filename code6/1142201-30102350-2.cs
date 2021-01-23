    public void OnPreviewLostKeyboardFocus(object sender, RoutedEventArgs e)
	{
		if ((sender as DataGridCell).Column.Header.ToString() == "The column I'm looking for")
		{
			e.Handled = true;
		}
	}
