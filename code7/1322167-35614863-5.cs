    public String ToString()
    {
        StringBuilder output = new StringBuilder();
    
        System.Reflection.PropertyInfo[] properties = this.GetType().GetProperties();
    
        foreach (System.Reflection.PropertyInfo property in properties)
        {
    		var values = property.GetValue(this, null) as IEnumerable<String>;
    		
    		if (values != null) 
    		{
    			int count = 0;
    			foreach (String value in values)
    			{
    				count++;
    				output.AppendLine(string.Format("C{0}: {1}", count, value));
    			}
    		}
        }
    	
    	return output.ToString();
    }
