	public static void Main()
	{
		var result = ChangeMaking(11);
		Console.WriteLine(string.Join(", ", result));
	}
	
	private static int ChangeMakingHelper(int input, int euro)
	{
		return input / euro;
	}
	
	static readonly int[] euro = { 1, 2, 5, 10, 20, 50, 100, 200, 500 };
	
	private static int[] ChangeMaking(int input)
	{
		var result = new int[euro.Length];
		for (int i = euro.Length -1; i >= 0; i--)
		{
			if (euro[i] <= input)
			{
				result[i] += ChangeMakingHelper(input, euro[i]);
				input = input - euro[i];
				if (input % euro[i] != 0)
				{
					var tempResult = ChangeMaking(input % euro[i]);
					// Transfer the results to the local result array
					for(int j = 0; j < result.Length; j++)
						result[j] += tempResult[j];
				}
                // Also add a break statement here so you don't add the lower values twice!
                break;
			}
		}
		return result;
	}
