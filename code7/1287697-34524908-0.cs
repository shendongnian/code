    public class A
    {    
        public A()
        {
        }
    }
    
    public class B : A
    {
        public B()
        {
    	}
    }
    
    public class C
    {
    	private void Method1(A obj)
    	{
    		if (obj is B)
    		{
    			Console.WriteLine("I'm B object!");
    		}
    		else
    		{
    			Console.WriteLine("I'm something else");
    		}
    	}
    }
    
    public class MainClass
    {
    	public static void Main()
    	{
    		B objectB = new B();
    		A objectA = new A();
    		C objectC = new C();
    		
    		MethodInfo method1 = typeof(C).GetMethod("Method1", BindingFlags.NonPublic | BindingFlags.Instance);
    		
    		method1.Invoke(objectC, new object[] { objectB });
    		method1.Invoke(objectC, new object[] { objectA });
    	}
    }
