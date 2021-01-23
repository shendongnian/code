    class Foo 
    {
    
    	static Foo() { Console.WriteLine("Static constructor is called."); }
    
    	public Foo() { Console.WriteLine("The constructor is called."); }
    	
    	public static void Bar() { Console.WriteLine("The static Bar method is called."); }
    }
    public static void Main()
    {
        Foo.Bar();
    }
