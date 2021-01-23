    public string status
    {
    	get
    	{
    		return date1 > DateTime.Today ? "Active" : "Inactive";
    	}
    }
