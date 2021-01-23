    Public class VMExample{
         public String p1 { get; set; }
         public String p2 { get; set; }
    }
    
    [HttpPost]
    public Json GetPass(VMExample parameters)
    {
    ...
    }
