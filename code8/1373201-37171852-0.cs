    public class ConsoleUtilities
    {
    	public static string ApplicationVersion
    	{
    		get
    		{
    			Assembly MyProgram = Assembly.GetEntryAssembly();
    			return MyProgram.GetName().Version.ToString();
    		}
    	}
    
    	public static ConsoleConfiguration Configuration = new ConsoleConfiguration();
    
    	/// <summary>
    	/// Show Text on the screen, and optionally write to LogPathFileName
    	/// </summary>
    	/// <param name="HelpText">Text to show</param>
    	/// <param name="LogPathFileName">Path and File Name of LogFile to write to. Use "" to not Log</param>
    	public static void ShowText(string[] HelpText, string LogPathFileName)
    	{
    		foreach (string HelpLine in HelpText)
    		{
    			ShowText(HelpLine, Configuration.BackgroundColor, Configuration.ForegroundColor, LogPathFileName);
    		}
    	}
    
    	public static void ShowText(string HelpLine, System.ConsoleColor Foreground, System.ConsoleColor Background, string LogPathFileName)
    	{
    		ShowTextOnConsole(HelpLine, Foreground, Background, true, LogPathFileName);
    	}
    }
    public class ConsoleConfiguration
    {
    	public ConsoleColor ForegroundColor { get; set; }
    	public ConsoleColor BackgroundColor { get; set; }
    	
    	public ConsoleConfiguration()
    	{
    		ForegroundColor = ConsoleColor.Gray;
    		BackgroundColor = ConsoleColor.Black;
    	}
    }
