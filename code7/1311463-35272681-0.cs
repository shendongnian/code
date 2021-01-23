    class ExampleClass
    {
    	public string DontSerializeIfNull {get;set;}
    	public string AlwaysSerialize {get;set;}
    	
    	public bool ShouldSerializeDontSerializeIfNull()
    	{
    		return DontSerializeIfNull != null;
    	}
    }
    
    JSON.Serialize(new ExampleClass { DontSerializeIfNull = null, AlwaysSerialize = null });
    // {"AlwaysSerialize":null}
    
    JSON.Serialize(new ExampleClass { DontSerializeIfNull = "foo", AlwaysSerialize = null });
    // {"AlwaysSerialize":null,"DontSerializeIfNull":"foo"}
    
    JSON.Serialize(new ExampleClass { DontSerializeIfNull = null, AlwaysSerialize = "bar" });
    // {"AlwaysSerialize":"bar"}
    
    JSON.Serialize(new ExampleClass { DontSerializeIfNull = "foo", AlwaysSerialize = "bar" });
    // {"AlwaysSerialize":"bar","DontSerializeIfNull":"foo"}
