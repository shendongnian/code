    // this sets a getter only property that returns the current value of _bootstrapBundle (equivalent to the last form in the code above)
    private static string _bootstrapBundle = "42";
    public static string BootstrapBundle => _bootstrapBundle;
    
    // this sets up an auto property (no backing field) that at initialization gets the initial value of _bootstrapBundle
    private static string _bootstrapBundle = "42";
    public static string BootstrapBundle {get;set;} = _bootstrapBundle;
    
    // equivalent to this:
    public static string BootstrapBundle {get;set;} = "42";
