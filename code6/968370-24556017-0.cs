    public Parent TheOnlyParent
    {
        get
        {
            if (theOnlyParent == null) {
                theOnlyParent = Parent.Create(TheOnlyParentId);
            }
            return theOnlyParent;
        }
        set
        {
    	 If(theOnlyParent != value){
                theOnlyParent = value;
                if (value != null) {
                    TheOnlyParentId = value.Id;
                }
            }
        }
    }
    
    private int theOnlyParentId;
    
    public int TheOnlyParentId
    {
        get
        {
            return theOnlyParentId;
        }
        set
        {
            if (theOnlyParentId != value) {
                theOnlyParentId = value;
                theOnlyParent = null;
            }
        }
    }
