    static void Main(string[] args)
    {
    	int[,] arr = new int[2, 2];
    	printArrayIndexes(arr);
    }
    
    private static void printArrayIndexes(object arr)
    {
    	var dimensArr = arr as Array;
    	List<int> indexList = new List<int>();
    	for (int dimension = 0; dimension < dimensArr.Rank; dimension++)
    	{
    		indexList.Add(0);
    	}
    	bool hasItems = true;
    	while (hasItems)
    	{
    		hasItems = false;
    		Console.Write("[");
    		for (int i = 0; i < indexList.Count; i++)
    		{
    			Console.Write(i < indexList.Count-1 ? indexList[i]+"," : indexList[i] + "");
    		}
    		Console.WriteLine("]");
    		for (int i = 0; i < indexList.Count; i++)
    		{
    			if (indexList[i] < dimensArr.GetLength(i)) {
    				hasItems = true;
    				indexList[i]++;
    				break;
    			} else {
    				indexList[i] = 0;
    			}
    		}
    	}
    }
