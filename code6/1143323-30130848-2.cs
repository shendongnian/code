    private void myTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		TabControl tc = (TabControl)e.Source;
		if(tc != null)
		{
			MyCustomTabItem ti = (MyCustomTabItem)tc.Items[tc.SelectedIndex];
			if(ti != null)
			{
				ti.MyCustomInitFunction()
			}
		}
	}
