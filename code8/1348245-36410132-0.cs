    class Derived : Base
    {
    	public new void Foo(int i)
    	{
    		Console.WriteLine("Foo(int)");
    	}
    
    	public void Foo(object i)
    	{
    		Console.WriteLine("Foo(object)");
    	}
    }
