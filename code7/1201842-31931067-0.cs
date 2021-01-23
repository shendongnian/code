    public Parent()
    {
    }
    
    public int ParentId { get; set; }
    
    public virtual List<Child> Children { get; set; }
    
    public Child Boy{ get{ return Children.First(<BoyCondition>); } }
    public Child Girl{ get{ return Children.First(<GirlCondition>); } }
