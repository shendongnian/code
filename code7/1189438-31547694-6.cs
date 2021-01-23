    public static void PullNonZerosToLeft(int[,] array, int row)
    {
        if (row > array.GetUpperBound(0))
        {
            return;
        }
        // Used to keep track of the swap point
        int index = 0;
        for (int i = row; i <= array.GetUpperBound(1); i++)
        {
            if (array[row, i] == 0)
            {
                continue;
            }
            int temp = array[row, i];
            array[row, i] = array[row, index];
            array[row, index] = temp;
            index++;
        }
    }
