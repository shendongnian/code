    public int Id { get; set; }
    public virtual Employee Employee { get; set; }
    public virtual Store Store { get; set; }
    public DateTime Beginning { get; set; }
    
    private DateTime _end;
    public DateTime End {
    	get
    	{
    		return _end;
    	}
    	set
    	{
    		if (value < Beginning)
    		{
    			throw new Exception("End date can not be less than beginning date.");
    		}
    		_end = value;
    	}
    }
