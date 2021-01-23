    namespace Test
    {
    	public class A
    	{
    		public int Foo { get; set; }
    	}
    
    	public class B : A
    	{
    		public int Bar { get; set; }
    	}
    
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var a = new B();
    		}
    	}
    }
