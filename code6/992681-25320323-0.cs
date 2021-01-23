    public static void Main (string[] args)
		{
			int maxWidth = 40;
			Console.WriteLine ("Please enter your desired character");
			string userChar = Console.ReadLine ();
			Console.WriteLine ("Please enter your desired width");
			int userWidth = Convert.ToInt32 (Console.ReadLine ());
			for (int i = 0; i < userWidth; i++) {
				for (int j = 0; j < i; j++) {
					Console.Write (" ");
				}
				Console.Write (userChar);
				for (int j = userWidth-1; j > i; j--) {
					Console.Write (" ");
				}
				for (int j = userWidth-1; j > 0+i ; j--) {
					Console.Write (" ");
				}
					
				Console.Write (userChar);
				Console.WriteLine ();
				}
			}
