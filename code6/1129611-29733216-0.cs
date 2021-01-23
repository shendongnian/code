    public void ReadLine()
    {	
    	var read = Console.ReadLine();
    	
    	a.Add(read);
    	
    	if (read != "|")
    		ReadLine();
    }
