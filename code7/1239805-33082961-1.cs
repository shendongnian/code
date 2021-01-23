    using System;
					
    class MyClass {
        protected string get_MyProperty(string Param1, string Param2)
        {
    		return "foo: " + Param1 + "; bar: " + Param2;
        }
        
        protected void set_MyProperty(string Param1, string Param2, string NewValue)
        {
    		// nop
        }
        // Helper class
        public class MyPropertyAccessor {
            readonly MyClass myclass;
            internal MyPropertyAccessor(MyClass m){
                myclass = m;
            }
            public string this [string param1, string param2]{
                 get {
                     return myclass.get_MyProperty(param1, param2);
                 }
                 set {
                     myclass.set_MyProperty(param1, param2, value);
                 }
            }
        }
        public readonly MyPropertyAccessor MyProperty;
        public MyClass(){
            MyProperty = new MyPropertyAccessor(this);
        }
    }
    
    
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		
    		var mc = new MyClass();
    		Console.WriteLine(mc.MyProperty["a", "b"]);
    	}
    	
    }
