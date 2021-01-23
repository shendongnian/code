    class Designation
    {
    	public string Number { get;set; }
    	public string Name { get;set; }
    	public string Description { get;set; }
    
    	public void Clear()
    	{
    		this.Number = string.Empty;
    		this.Name = string.Empty;
    		this.Description = string.Empty;
    	}
    }
