    public struct combo { public int number1; public int number2; public int number3; public int number4; public int number5; public int sum; public bool invalid; }
    
    void ProcessList(List<combo> list)
    {
    	int count = 0;
    	for (int i = 0; i < list.Count; i++)
    	{
    		var item = list[i];
    		ProcessItem(ref item);
    		if (!item.invalid) list[count++] = item;
    	}
    	list.RemoveRange(count, list.Count - count);
    }
    
    void ProcessItem(ref combo item)
    {
    	// do the processing and set item.invalid=true/false
    }
