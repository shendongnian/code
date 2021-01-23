    public class ClassA
    {
    	public ClassB ClassB1 { get; set; }
    	public ClassB ClassB2 { get; set; }
    	
    	public ClassA()
    	{
    		// pass `this` to `ClassB` in the constructor
    		this.ClassB1 = new ClassB(this);
    		
    		// pass `this` to a property in `ClassB`
    		this.ClassB2 = new ClassB();
    		this.ClassB2.ClassA = this;
    	}
    }
    
    public class ClassB
    {
    	public ClassA ClassA { get; set; }
    	
    	public ClassB() { }
    	
    	public ClassB(ClassA classA)
    	{
    		this.ClassA = classA;
    	}
    }
