    void Main()
    {
    	DoSomething();
    }
    
    void DoSomething(){
    	Console.WriteLine (Environment.StackTrace); // Last frame: at System.Environment.GetStackTrace(Exception e, Boolean needFileInfo)
    	
    	var frames = new StackTrace().GetFrames();
    	var lastframe = frames[0]; // last frame: DoSomething at offset 100 in file:line:column <filename unknown>:0:0
    	var methodField = lastframe.GetType().GetField("method", BindingFlags.Instance | BindingFlags.NonPublic);
    	var redirectedMethod = typeof(Redirect).GetMethod("RedirectToMethod", BindingFlags.Instance | BindingFlags.Public);
    	methodField.SetValue(lastframe, redirectedMethod);
    	Console.WriteLine (frames); // last frame: RedirectToMethod at offset 100 in file:line:column <filename unknown>:0:0
    	Console.WriteLine (Environment.StackTrace); // last frame: at System.Environment.GetStackTrace(Exception e, Boolean needFileInfo)
    }
    
    public class Redirect {
    	public void RedirectToMethod() { }
    }
