    private static int[,] CountingSort2D(int[,] arr)
    {
        // find the max number by first item of each row
        int max = arr[0, 0];
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            if (arr[i, 0] > max) max = arr[i, 0]; 
        }
        // we want to get count of first items of each row. thus we need 1d array.
        int[] counts = new int[max + 1]; 
        // do the counting. again on first index of each row
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            counts[arr[i, 0]]++; 
        }
        for (int i = 1; i < counts.Length; i++)
        {
            counts[i] += counts[i - 1];
        }
        // result is sorted array
        int[,] result = new int[arr.GetLength(0), arr.GetLength(1)];
        for (int i = arr.GetLength(0) - 1; i >= 0; i--)
        {
            counts[arr[i, 0]]--;
            // now we need to copy columns too. thus we need another loop
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                result[counts[arr[i, 0]], j] = arr[i, j];
            }
        }
        return result;
    }
