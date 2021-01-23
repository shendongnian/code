    bool firstcolumn= false, secondcolumn = false, thirdcolumn= false;
    		
    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    List<string> list1 = new List<string>();
    List<string> list2 = new List<string>();
    List<string> list3 = new List<string>();
    for (int i = 0; i < line.Length; i++)
    {
    	if(line[i] != ',' && i != line.Length -1) 
    	{
    		sb.Append(line[i]);
    		continue;
    	}
    	
    	if(!firstcolumn)
    	{
    		firstcolumn = true;
    		list1.Add(sb.ToString());
    		
    	}
    	else if(!secondcolumn)
    	{
    		secondcolumn = true;
    		list2.Add(sb.ToString());
    		
    	}
    	else
    	{
    		thirdcolumn = true;
    		list3.Add(sb.ToString());
    	}
    	
    	sb.Clear();    	
    }
