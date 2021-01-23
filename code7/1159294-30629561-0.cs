    public Section() 
    {
    	this.Items = new List<Item>();
    	
    	public Invoice Parent { get; set; }
    	
    	public Section(Invoice parent) 
    	{
    		this.Parent = parent;
    	}
    }
