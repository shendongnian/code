	public static void Main( string[] args )
	{
		int variable1;
		int variable2;
		int variable3;
		//test
		double average;
		int sum;
		int remainder;
		string thelist;
		string variable11;
		string variable21;
		string variable31;
		Console.Write( "Enter a number:" );
		variable1 = Convert.ToInt32( Console.ReadLine() );
		//variable11 = Convert.ToString32( Console.ReadLine() ); not needed.
		Console.Write( "Enter another number:" );
		variable2 = Convert.ToInt32( Console.ReadLine() ); 
		//variable21 = Convert.ToString32( Console.ReadLine() ); not needed
		Console.Write("one more:");
		variable3 = Convert.ToInt32(Console.ReadLine()); 
		//variable31 = Convert.ToString32( Console.ReadLine() ); not needed
		sum = variable1 + variable2 + variable3;
		average = sum / 3;
		remainder = sum % 3;
		//pass the values in and use placeholders {0} to {5}
		Console.WriteLine( "the average of {0}, {1}, & {3} is {4} with a remainder of {5}" , variable1 , variable2, variable3, average, remainder); 
		Console.WriteLine( "THE remainder: {0}", remainder );
		//need spaces before quotes
		 Console.ReadLine();
	}
}
