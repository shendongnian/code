    int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    List<int[]> b = new List<int[]>();
    
    for (int i = 0; i < ((a.Length % 3 == 0) ? a.Length / 3 : a.Length / 3 + 1); i++)
    {
    	int bLength = (i + 1) * 3 < a.Length ? 3 : a.Length % 3;
    	int[] bTemp = new int[bLength];
    	for (int j = 0; j < bLength; j++)
    	{
    		bTemp[j] = a[i * 3 + j];
    	}
    	b.Add(bTemp);
    }
