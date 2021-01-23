    public class Program
    {
    	public void Main(string[] args)
    	{
            // named delegate
    		Tasker t = new Tasker();
    		t.doer += DoProvider.DoThis;
    		t.CallDoer("I am doing something");
    		
            // anonymous method
    		Tasker t2 = new Tasker();
    		t2.doer += delegate(string s){
    			Console.WriteLine (s);
    		};
    		t2.CallDoer("I am doing something again");
    		
            // syntactical sugar over anonymous methods aka lambda expressions
    		Tasker t3 = new Tasker();
    		t3.doer += (s)=>{
    			Console.WriteLine (s);
    		};
    		t3.CallDoer("I am doing yet another thing");
    	}
    }
    
    
    public delegate void DoSomething(string Foo);
    
    public class Tasker
    {
    	public event DoSomething doer;
    	
    	public void CallDoer(string s)
    	{
    		doer.Invoke(s);
    	}
    }
    
    public static class DoProvider
    {
    	public static void DoThis(string Bar)
    	{
    		Console.WriteLine (Bar);
    	}
    }
