    void Main()
    {
    	Foo f1 = new Foo("good",6);
    	Foo f2;
    	string temp_string;
    	
    	// You can do this
    	temp_string = f1.S;
    	// Bot not this
    	// temp_string = f2.S; --> Use of unassigned local variable 'f2'
    
    	// You can also do this: 
    	int temp_int = Foo.I;
    	// But  not
    	// temp_int = f1.I; 
    	
    	// You can do
    	bool b = TestFoo(f1);
    	// But not
    	// b = TestFoo(f2); --> Use of unassigned local variable 'f2'
    }
    
    public class Foo {
    	// static class property, can be accessed with "Foo.I"
    	public static int I {get; set;}
    
    	// instance property, can be accessed with "f1.S"
    	public string S { get; set; }
    	
    	public Foo(string s, int i = 0) {
    		S = s;
    		I = i;
    	}
    }
    
    public bool TestFoo(Foo foo) {
    	return foo != null;
    }
