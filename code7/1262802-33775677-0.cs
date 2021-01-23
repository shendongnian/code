    public class Program
    {
    	static int TOTAL_NUMBER_CHARS_PER_LINE = 64;
    	
    	public static void Main()
    	{		
    		DisplayHelpEx();
    	}
    	
        // i only set test params here
    	public static void DisplayHelpEx()
    	{
    		string ParameterName = "myOption";
    		string Explanation = "Text do describe the option, but that should be splitted to several lines if too big. Text should automatically align by a fixed offset";
    		int offset = ParameterName.Length + 6;
    				
    		Console.WriteLine("The following options are possible:");
    	    
            // print caption
    		Console.Write((ParameterName + ": ").PadLeft(offset));
            // print help
    		WriteOffset(offset, TOTAL_NUMBER_CHARS_PER_LINE - offset, Explanation);	
    	}
