    private void lstSearchCategory_Tap(object sender, System.Windows.Input.GestureEventArgs e)
	{
		try
		{
			ListBox ListBoxSelecteditem = (ListBox)sender;
			YourModel model = (YourModel)ListBoxSelecteditem.SelectedItem;
			string ControlName = ((System.Windows.FrameworkElement)(((System.Windows.RoutedEventArgs)(e)).OriginalSource)).Name;
			if (ControlName.ToLower() != "name".ToLower())
			{
			}
		}
		catch (Exception ex)
		{ }
	}	
