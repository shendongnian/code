    using System;
						
	public class Program
	{
		public static void Main()
		{
			// Define answers
			string[] answers = new[] {
				"Some answer",
				"Another answer",
				"Yet another answer",
				"Foo answer",
				"Bar answer"
			};
			
			// Create a new instance of the Random class
			var rng = new Random();
			
			// Pick a random number between 0 and the number of elements in the answers array
			int randomnumber = rng.Next(0, answers.Length);
			
			// Print random answer
			Console.WriteLine(answers[randomnumber]);
		}
	}
