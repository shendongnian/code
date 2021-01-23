    public void button_Click(object sender, RoutedEventArgs e)
    {
    	var button = (Button)sender;
    	if (button.Style != myButtonStyle)
    		button.Style = myButtonStylePressed;
    	else
    		button.Style = myButtonStyle;
    }
