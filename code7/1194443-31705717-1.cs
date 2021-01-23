    static class MainClass
    {
    	static void Main (string[] args)
    	{
    		Console.WriteLine (args[0]);
    		NSApplication.Init ();
    		NSApplication.Main (args);
    	}
    }
