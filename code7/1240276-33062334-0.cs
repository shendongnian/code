    public class Program
    {
    	public void Main(string[] args)
    	{
    		Foo foo = new Foo();
    		foo.SomeMethod(ActionProvider.ShowMessageBox);
    	}
    }
    
    public static class ActionProvider
    {
    	public static void ShowMessageBox()
    	{
    		//Write code for showing message box
    		Console.WriteLine("Showing message box");
    	}
    }
    
    // Assume this class to be in another dll
    public class Foo
    {
    	public void SomeMethod(Action callback)
    	{
    		//Do something
    		callback();
    		//Do something else
    	}
    }
