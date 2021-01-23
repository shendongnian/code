    [ComVisible(true)]
    public class ScriptManager
    {
    	protected Window Window { get; set; }
    
    	public ScriptManager(Window window)
    	{
    		this.Window = window;
    	}
    
    	public void CloseWindow()
    	{
    		this.Window.Close();
    	}
    }
