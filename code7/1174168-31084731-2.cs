    protected void OnButton2Clicked (object sender, EventArgs e)
    {
    	var rect = button.Allocation;
    	PropertyInfo[] properties = rect.GetType().GetProperties();
    	var sb = new System.Text.StringBuilder();
    	foreach (PropertyInfo pi in properties)
    	{
    		sb.Append(
    			string.Format("Name: {0} | Value: {1}\n", 
    				pi.Name, 
    				pi.GetValue(rect, null)
    			) 
    		);
    	}
    	Console.WriteLine (sb);
    }
