    private void Confirm_Click(object sender, RoutedEventArgs e)
    {
    	Frame.Navigate(typeof(Confirmation) , TotalValue);
    }
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
    	var totalValue = e.Parameter as string; // or 'as' whatever is type of TotalValue
    
    	if (totalValue != null) 
    	{
    		COsttxt.Text = string.Format("{0:C}", totalValue);
    	}
    }
