	public class Program
	{	
		private const string InputTerminationString = "Q";
		
		public static void Main()
		{
			List<Player> players = new List<Player>(); // p. 1, 4
			
			while (true)
			{
				Console.Write("Enter name: ");
				string name = Console.ReadLine();
				if (name == InputTerminationString)	break; // p. 2
				
				Console.Write("Enter score for {0}: ", name); // p. 3
				int score = int.Parse(Console.ReadLine());
				
				players.Add(new Player { Name = name, Score = score }); 
			}
			
			Console.WriteLine("Name           Score");
			players.ForEach(x => Console.WriteLine("{0, -16} {1, 8}", x.Name, x.Score)); // p. 5
			
			double average = players.Average(x => x.Score); // p. 6
			Console.WriteLine("Average score: {0:F2}", average); // p. 3
			
			Console.WriteLine("Players who scored below average");
			Console.WriteLine("Name           Score");
			players
				.Where(x => x.Score < average) // p. 7
				.ToList()
				.ForEach(x => Console.WriteLine("{0, -16} {1, 8}", x.Name, x.Score)); // p. 5			
		}
	}
	public class Player
	{
		public string Name { get; set; }
		public int Score { get; set; }	
	}
