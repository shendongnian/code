    namespace ConsoleApplication1 {
    	class Program {
    		static void Main(string[] args) {
    
    			while (true) { //read 2. assuming this is to be run forever in this example, but gives also some way to break the loop whenever necessary in your app
    				if (DateTime.Now.TimeOfDay.TotalSeconds <= 1) { //read 1. and 3. this way, you give tolerance of 1 second. Your action will be run on 12:00:00 - 12:00:01
    					Console.WriteLine("Do action to run query truncate");
    					//	//in this line i will execute query truncate.
                        break; //break after saving once, for instance, and run again when the time close...
    				}
    				System.Threading.Thread.Sleep(500); //read 2. and 3. check every 500 millisecond, at least to give chance to check the time twice per second
    			}
    
    			// Keep the console window open in debug mode.
    			Console.WriteLine("Press any key to exit.");
    			Console.ReadKey();
    		}
    	}
    }
