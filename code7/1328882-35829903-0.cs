    Using System; // <-- You need this for Console
    
    class Program
    {
        static void Main()
        {
    	//
    	// 1. Type "Console" and press "."
    	// 2. Select "BackgroundColor".
    	// 3. Press space and "=", then press tab.
    	//
    	Console.BackgroundColor = ConsoleColor.Blue;
    	Console.ForegroundColor = ConsoleColor.White;
    	Console.WriteLine("White on blue.");
    	Console.WriteLine("Another line."); // <-- This line is still white on blue.
    	Console.ResetColor();
        }
    }
