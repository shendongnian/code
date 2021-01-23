    public sealed class B : A
    {
    	public B(string name) : base(name)
    	{
    	}
    
    	public override void Foo()
    	{
    		Tag = "B";
    	}
    
    	public string Tag { get; set; }
    
    	protected B(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt)
    	{
    	}
    }
