    var original = new int[2,2,2] { { { 1, 2 }, { 3, 4} }, { { 5, 6 }, { 7, 8 } } };
    
    var serialized = original.Cast<int>().ToArray();
    var originalBounds = Enumerable.Range(0, original.Rank)
        .Select(i => original.GetUpperBound(i) + 1).ToArray();
    
    var empty = Array.CreateInstance(typeof(int), originalBounds);
    
    var indices = new int[empty.Rank];
    indices[indices.Length - 1]--;
    var index = 0;
    while (IncArray(empty, indices))
    {
        empty.SetValue(serialized[index++], indices);
    }
    private bool IncArray(Array array, int[] indices)
    {
    	int rank = array.Rank;
    	indices[rank - 1]++;
    	for (int i = rank - 1; i >= 0; i--)
    	{
    		if (indices[i] > array.GetUpperBound(i))
    		{
    			if (i == 0)
    			{
    				return false;
    			}
    			for (int j = i; j < rank; j++)
    			{
    				indices[j] = 0;
    			}
    			indices[i - 1]++;
    		}
    	}
    	return true;
    }
