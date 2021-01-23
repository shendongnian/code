    set
    {
    	int itemIndex = 1;
        if (initialStopCollection == null) initialStopCollection = new ...; // your initialStopCollection is null. Create new one
    	if (itemIndex >= initialStopCollection.Count) // Two few items, create new
    	{
    		for (int i = initialStopCollection.Count; i <= itemIndex; i++)
    		{
    			initialStopCollection.Add(new ...);
    		}
    	}
    	if (initialStopCollection[itemIndex] == null) initialStopCollection[itemIndex] = new ... ; // This item is not initialized, create new
    	initialStopCollection[itemIndex].BufferUAbsolute = value;
    }
