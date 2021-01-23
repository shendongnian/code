    public class ClassA
    {
    	public ClassB MyClassB1 { get; set; }
    	public ClassB MyClassB2 { get; set; }
    	
    	public ClassA()
    	{
    		// pass `this` to the constructor
    		this.MyClassB1 = new ClassB(this);
    		
    		// pass `this` directly to a property in `ClassB`
    		this.MyClassB2 = new ClassB();
    		this.MyClassB2.MyClassA = this;
    	}
    }
    
    public class ClassB
    {
    	public ClassA MyClassA { get; set; }
    	
    	public ClassB() { }
    	
    	public ClassB(ClassA classA)
    	{
    		// do property assignment in the constructor
    		this.MyClassA = classA;
    	}
    }
