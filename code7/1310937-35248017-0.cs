    public static int LargestSum(int[,] array)
    {
        int firstLargest = 0, secondLargest = 0, thirdLargest = 0;
        for(int x = 0; x < array.GetLength(0); x++)
        {
            for(int y = 0; y < array.GetLength(1); y++)
            {
                int value = array[x, y];
                if(value > thirdLargest)
                {
                    if (value > secondLargest)
                    {
                        if (value > firstLargest)
                        {
                            thirdLargest = secondLargest;
                            secondLargest = firstLargest;
                            firstLargest = value;
                        }
                        else
                        {
                            thirdLargest = secondLargest;
                            secondLargest = value;
                        }
                    }
                    else
                    {
                        thirdLargest = value;
                    }
                }
            }
        }
        return firstLargest + secondLargest + thirdLargest;
    }
