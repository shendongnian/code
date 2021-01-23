	static void InitIntArray(int[] arr, int k){
		Random rnd = new Random();
		for(int i = 0; i < arr.Length; i++)
		{
            //Probability this array element is a 1
			double p = (double)k / (arr.Length-i);
			if(rnd.NextDouble() < p)
			{
				arr[i] = 1;
				k--;
			}
			else
			{
				arr[i] = 0;
			}
		}
	}
