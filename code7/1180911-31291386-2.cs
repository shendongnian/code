    // get/set methods omitted	
    
    public static readonly DependencyProperty IsTextMatchProperty =
    		DependencyProperty.RegisterAttached(
    			"IsTextMatch", 
    			typeof(bool), 
    			typeof(GridBehavior), 
    			new FrameworkPropertyMetadata(GridBehavior.OnIsTextMatchPropertyChanged));
    
    	private static void OnIsTextMatchPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    	{
    		var counter = d.GetValue(GridBehavior.CellsCounterProperty) as Counter;
    		if (counter == null)
    		{
    			return;
    		}
    
    		if ((bool)e.NewValue)
    		{
    			counter.Add(d);
    		}
    		else
    		{
    			counter.Remove(d);
    		}
    	}
