    int[] TempArray = new int[] {1,3,-1,5,7,-1,4,10,9,-1};
    int[] Original ; 
    int countNonNegative=0;
     for (int i = 0; i < TempArray.Length; i++)
    {
                if (TempArray[i] != -1)
                {
                    countNonNegative++;
                }
     }
        Original = new int[countNonNegative];
        int index=0;
        for (int i = 0; i < TempArray.Length; i++)
        {
                if (TempArray[i] != -1)
                {
                    Original[index] = TempArray[i];
                    index++;
                }
        }
        Console.WriteLine("Original Length = "+Original.Length);
