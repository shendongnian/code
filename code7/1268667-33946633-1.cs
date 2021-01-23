    class Program
    {
        string someUserName;
 
        static void Main()
        {
    	while (true) // Loop indefinitely
    	{
    	    Console.WriteLine("Enter input:"); // Prompt
    	    string line = Console.ReadLine(); // Get string from user
    	    if (line == "exit") // Check string
    	    {
    		    break;
    	    }
    	    Console.Write("You typed "); // Report output
    	    Console.Write(line.Length);
    	    Console.WriteLine(" character(s)");
            if(someUserName != line)
            {
               // New username has been detected
            }
           
    	}
        }
    }
