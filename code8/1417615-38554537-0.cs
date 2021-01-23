    public class A : ISerializable
    {
    	public A(string name)
    	{
    	}
    
    	public virtual void Foo()
    	{
    	}
    
    	protected A(SerializationInfo info, StreamingContext ctxt)
    	{
    		Foo();
    	}
    
    	public void GetObjectData(SerializationInfo info, StreamingContext context)
    	{
    	}
    }
    
