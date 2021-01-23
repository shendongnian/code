    private Object _lock = new Object();
    
    private void CollectionChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        updateDisplay();
    }
    
    private void updateDisplay()
    {
    	lock (_lock)
    	{
    	 	items.CollectionChanged -= CollectionChangedEvent;
    
    		display.clear();
    
    		foreach(item i in items)
    		{
    		 	display.add(i);
    		}
    
    		items.CollectionChanged += CollectionChangedEvent;
    	}
    }
