    class Derived2 : Derived1
    {
    	new void fun()
    	{
    		Console.Write("Derived2 class" + " ");
    	}
    
    	public void Test()
    	{
    		fun();
    	}
    }
    class Program
    {
    	public static void Main(string[] args)
    	{
    		Derived2 d = new Derived2();
    		d.Test(); //Prints 'Derived2 class'
    	}
    }
