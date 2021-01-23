    private void SelectRowDetails(object sender, MouseButtonEventArgs e)
    {
    	if(e.Source is DataGridDetailsPresenter) // Like this
    	{
    		var row = sender as DataGridRow;
    		if (row == null)
    		{
    			return;
    		}
    		row.Focusable = true;
    		row.Focus();
    
    		var elementWithFocus = Keyboard.FocusedElement as UIElement;
    		if (elementWithFocus != null)
    		{
    			elementWithFocus.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
    		}
    	}            
    }
