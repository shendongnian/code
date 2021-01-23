	public class Program
	{
		public static void Main()
		{
			var UserValue = "1 2 3 4";
			var Message = "";
			Message = (UserValue == "1 2 3 4") ? Program.x() : Program.y();
			Console.WriteLine(Message);		
		}
	
		static Func<string> x = () => {
			Console.Beep(250, 250);
			return "Correct";
		};	
	
	
		static Func<string> y = () => {
			Console.Beep(130, 250);
			return "Incorrect";
		};		
	
	}
