    private bool JustChecked;
    private void RB_Checked(object sender, RoutedEventArgs e)
    {
    	RadioButton s = sender;
    	// Action on Check...
    	JustChecked = true;
    }
    
    private void RB_Clicked(object sender, RoutedEventArgs e)
    {
    	if (JustChecked) {
    		JustChecked = false;
    		e.Handled = true;
    		return;
    	}
    	RadioButton s = sender;
    	if (s.IsChecked)
    		s.IsChecked = false;
    }
