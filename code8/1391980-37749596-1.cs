    int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    int[][] b = new int[((a.Length % 3 == 0) ? a.Length / 3 : a.Length / 3 + 1)][];
    
    for (int i = 0; i < b.Length; i++)
    {
    	b[i] = new int[(i + 1) * 3 < a.Length ? 3 : a.Length % 3];
    	int[] bTemp = new int[b[i].Length];
    	for (int j = 0; j < b[i].Length; j++)
    	{
    		bTemp[j] = a[i * 3 + j];
    	}
    	b[i] = bTemp;
    }
