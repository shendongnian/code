	public static void Main()
	{
		char[] arr = new char[5];
		//User input
		Console.WriteLine("Please Enter 5 Letters only: ");
	
		for (int i = 0; i < arr.Length; i++)
		{
			 char input;
			
			if(char.TryParse(Console.ReadLine(), out input) && !arr.Any(c=>c == input))
			{			
			
				arr[i] = input;
			}
			else
			{
				Console.WriteLine( "Error : Either invalid input or a duplicate entry.");
				i--;
			}
		}
		
		Console.WriteLine("You have entered the following inputs: ");
		//display
		for(int i = 0; i<arr.Length; i++)
		{
			
			Console.WriteLine(arr[i]);
		}
			
	}
