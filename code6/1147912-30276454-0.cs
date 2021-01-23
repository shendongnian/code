    public int GetSmallestIndex(long[] numbers, long x, long m)
    {
        if (numbers.Length >= 2)
        {
            for (int j = 1; j < numbers.Length; j++)
            {
                for (int i = 0; i < j; i++)
                {
                    long diff = Math.Abs(numbers[j] - numbers[i]); 
                    if (diff <= x || diff >= m - x)
                        return j;
                }
            }
        }
        return -1; //If no solution is found, return -1 as convention
    }
