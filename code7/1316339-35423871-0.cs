    var rowCollection = GetData();
    
    for(int iRow = 0; iRow < RowCount; iRow++)
    {
    	if(iRow["Col"] > 0)
    	{
    		rowCollection = GetData();
    		irow = 0;
    	}
    	else
    	{
    		//some processing statement
    	}
    }
