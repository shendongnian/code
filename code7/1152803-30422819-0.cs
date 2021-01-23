    public static void Main()
	{
		List<List<Byte>> bytes = new List<List<Byte>>(){
											new List<Byte> {0, 1, 2, 3, 4},
											new List<Byte> {0, 0, 2, 4, 1},
											new List<Byte> {1, 2, 2, 1, 1},
											new List<Byte> {1, 0, 2, 2, 2}
									};
		var result = bytes.OrderBy(x => String.Join(String.Empty, x));
		
		foreach (var list in result)
		{
			foreach (var bit in list)
				Console.Write(bit);
			
			Console.WriteLine();
		}	
	}
