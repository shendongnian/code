    public class BaseClass
    {
    	public virtual void FunctionA() { ... }
    	public void FunctionAVariant1() { ... }
    	public void FunctionAVariant2() { ... }
    }
    
    public class DerivedClass1 : BaseClass
    {
    	public override void FunctionA()
    	{
    		base.FunctionAVariant1();
    	}
    }
    
    public class DerivedClass2 : BaseClass
    {
    	public override void FunctionA()
    	{
    		base.FunctionAVariant2();
    	}
    }
