    public class ClassA
    {
    	public ClassB classB { get; set; }
    	
    	public ClassA()
    	{
    		this.classB = new ClassB(this);
    	}
    }
    
    public class ClassB
    {
    	public ClassA classA { get; set; }
    	
    	public ClassB(ClassA classA)
    	{
    		this.classA = classA;
    	}
    }
