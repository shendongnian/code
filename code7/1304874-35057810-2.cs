    public interface ITypeA<out A>
    	where A : ClassA
    {
    	A p1
    	{
    		get;
    	}
    }
    
    public class ClassA
    {
    }
    
    public class TypeA<A> : ITypeA<A> where A : ClassA
    {
    	public A p1
    	{
    		get;
    		set;
    	}
    }
    
    public class SubTypeA<A> : TypeA<A> where A : ClassA
    {
    	public TypeA<A> p2
    	{
    		get;
    		set;
    	}
    
    	public void foo()
    	{
    		var x = new TypeA<ClassA>();
    		ITypeA<ClassA> y = p2;
    	}
    }
