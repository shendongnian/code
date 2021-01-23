    int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    // if the length % 3 is zero, then it has length / 3 values
    // but if it doesn't go without rest, the length of the array in the first dimention is + 1
    int[][] b = new int[((a.Length % 3 == 0) ? a.Length / 3 : a.Length / 3 + 1)][];
    
    for (int i = 0; i < b.Length; i++)
    {
        // the length of the second dimension of the array is the 3 if it goes throught 3
        // but if it has rest, then the length is the rest
    	b[i] = new int[(i + 1) * 3 <= a.Length ? 3 : a.Length % 3];
    	int[] bTemp = new int[b[i].Length];
    	for (int j = 0; j < b[i].Length; j++)
    	{
    		bTemp[j] = a[i * 3 + j];
    	}
    	b[i] = bTemp;
    }
