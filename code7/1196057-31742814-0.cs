    public override object this[int i]
    {
    	get
    	{
    		return this.GetValue(i);
    	}
    }
    public override object this[string name]
    {
    	get
    	{
    		return this.GetValue(this.GetOrdinal(name));
    	}
    }
