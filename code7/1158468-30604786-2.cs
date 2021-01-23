    public void RestoreValues()
    {   
    	var controlContainer = VisualTreeHelper.GetChild(???, ???) as FrameworkElement;
    	if (controlContainer != null)
    	{
    		foreach (var keyValuePair in App.globalDictionary)
    		{
    			var doubleTextBox = controlContainer.FindName(keyValuePair.key) as syncfusion:DoubleTextBox;
    			if (doubleTextBox != null)
    				doubleTextBox.Value = keyValuePair.Value;
    		 }
    	 }
    }
