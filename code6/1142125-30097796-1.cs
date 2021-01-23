	using System;
						
	public class Program
	{
        public string A { get; set; }
		public static void Main()
		{
			string a = "A";
			switch (a)
			{
				case nameof(Program.A):
				{
					Console.WriteLine("yes!");
					break;
				}
			}
		   
		}
	}
