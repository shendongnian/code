    public void RestoreValues()
    {
        var codeBehindClassType = GetType();
        var properties = codeBehindClassType.GetProperties();
    
    	var controlContainer = VisualTreeHelper.GetChild(???, ???) as FrameworkElement;
    	if (controlContainer != null)
    	{
    		foreach (var keyValuePair in App.globalDictionary)
    		{
    			var doubleTextBox = controlContainer.FindName(keyValuePair) as syncfusion:DoubleTextBox;
    			if (doubleTextBox != null)
    				doubleTextBox.Value = keyValuePair.Value;
    		 }
    	 }
    }
