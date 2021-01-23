    // this defines a public getter, public setter property with no backing field (there is an internal one, but not one you can access)
    public static string BootstrapBundle {
    	get;
    	set;
    } 
    
    // this defines a public getter, public setter property with a backing field
    private static string _bootstrapBundle = "42";
    public static string BootstrapBundle {
    	get {
    		return _bootstrapBundle;
    	}
    	set {
    		_bootstrapBundle = value;
    	}
    }
    
    //this defines a no setter property with a backing field
    private static string _bootstrapBundle = "42";
    public static string BootstrapBundle {
    	get {
    		return _bootstrapBundle;
    	}
    }
