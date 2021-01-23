    public ChildMap() 
    {
        ...
        BatchSize(100);  // this is the way how to solve 1 + N (good practice, mine at least)
    
        // How should I set this up?
        References(x => x.Parent) // References, not Reference
            .Cascade.SaveUpdate()
            ;
    }
    
    public ParentMap() 
    {
        ...
        BatchSize(100);  // this is the way how to solve 1 + N
    
        // How should I set this up ?
        HasMany(x => x.Children)
           .BatchSize(100)  // no 1 + N
           .Cascade.AllDeleteOrphan()
           .Inverse()
           ;
