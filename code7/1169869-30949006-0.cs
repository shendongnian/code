    public static String SearchInTwoDimArray()
    {
        int[,] arr = {
            {1,2,3,4},
            {5,6,7,8},
            {12,50,7,8} };
        int searchFor = 50;
        int[] index = { -1, -1 };
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] == searchFor)
                {
                     index[0] = i;
                     index[1] = j;
                     return("Found " + searchFor + " at raw " + index[0] + " column " + index[1]);
                }
            }
        
        }
        return("Not Found");
        // Console.ReadLine();  // put this line outside of the function call
    }
