    	public class Program
    	{	
    		private const string InputTerminationString = "Q";
    		
    		public static void Main()
    		{
    			List<Player> players = new List<Player>();    		
    			
    			while (true)
    			{
    				Console.Write("Enter name: ");
    				string name = Console.ReadLine();
    				if (name == InputTerminationString)
    					break;
    				
    				Console.Write("Enter score for {0}: ", name);
    				int score = int.Parse(Console.ReadLine());
    				
    				players.Add(new Player { Name = name, Score = score });
    			}
    			
    			Console.WriteLine("Name           Score");
    			players.ForEach(x => Console.WriteLine("{0, -16} {1, 8}", x.Name, x.Score));			
    			
    			double average = players.Average(x => x.Score);
    			Console.WriteLine("Average score: {0:F2}", average);
    			
    			Console.WriteLine("Players who scored below average");
    			Console.WriteLine("Name           Score");
    			players
    				.Where(x => x.Score < average)
    				.ToList()
    				.ForEach(x => Console.WriteLine("{0, -16} {1, 8}", x.Name, x.Score));			
    		}
    	}
    
    	public class Player
    	{
    		public string Name { get; set; }
    		public int Score { get; set; }	
    	}
