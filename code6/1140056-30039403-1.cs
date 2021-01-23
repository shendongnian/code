    private MyEnum _MyProperty = MyEnum.Default;
    
    [System.ComponentModel.Bindable(true)]
    public MyEnum MyProperty
    {
    	get {
    		return _MyProperty;
    	}
    	set {
    		_MyProperty = value;
    	}
    }
    
    public string MyPropertyString 
    {
    	get {
    		return _MyProperty.ToString();
    	}
    	set {
    		_MyProperty = (MyEnum)Enum.Parse( typeof(MyEnum), value, true );
    	}
    }
