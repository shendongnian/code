	public static void Main()
	{
		var maxBit = 5;
						  
		foreach( var num in new[]{ 1,2,3,4, 5, 7, 8 }){
		
			Console.WriteLine("Num: " + num);
		
			for( var i = 1; i <= maxBit; i++ ){
				
				var bit = (num & (1 << i-1)) != 0;
				
				Console.Write(bit + " ");
			}
			Console.WriteLine("");
		}
	
	}
