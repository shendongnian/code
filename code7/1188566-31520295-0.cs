    private readonly Form _parent;
    
    public SecondForm (Form parent)
    {
    	_parent = parent; 
    }
    
    public void SomethingHappend ()
    {
    	_parent.Size = this.Size;
    }
