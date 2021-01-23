    void Main()
    {
    	var a = new List<A>{
    		new A(),
    		new B(),
    		new C()
    	};
    	
    	//1
    	Console.Write(a.Where(x => x is C).ToList().Count());
    }
    
    public class A {
    	string a;
    }
    
    public class B: A {
    	int b;
    }
    
    public class C: B {
    	long c;
    }
