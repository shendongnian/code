    class Program
    {
    	static void Main(string[] args)
    	{
    		string Studentname;
    		string retry = "Yes";
    
    		Console.WriteLine("What is the Student's name? ");
    		while (retry != "No")
    		{
    			Console.WriteLine("What is the Student's name? ");
    			Studentname = Console.ReadLine();
    
    			switch (Studentname)
    			{
    				case "George":
    					Console.WriteLine("Yes in the list");
    					//Console.ReadLine();
    					break;
    				case "Goblin":
    					Console.WriteLine("Yes in the list");
    					//Console.ReadLine();
    					break;
    				case "Peter":
    					Console.WriteLine("Yes in the list");
    					//Console.ReadLine();
    					break;
    				case "TJ":
    					Console.WriteLine("Yes in the list");
    					//Console.ReadLine();
    					break;
    				default:
    					Console.WriteLine("Not in the list");
    					Console.WriteLine("Would you like to retry?");
    					retry = Console.ReadLine();
    					break;
    			}
    		}
    	}
    }
