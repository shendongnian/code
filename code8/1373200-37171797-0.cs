    public class ConsoleUtilities
    {
       public static bool ShowLog { get; set; } = true; // true, if we want log messages to be printed
       public static void Log(string[] HelpText, string LogPathFileName)
       {
        if (ShowLog) {
        foreach (string HelpLine in HelpText)
        {
            ShowText(HelpLine, System.ConsoleColor.Gray, System.ConsoleColor.Black, LogPathFileName);
        }
       }
    }
