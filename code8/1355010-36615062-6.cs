    public static int GetClosestIndex(int[] arr, int value)
    {
        int result = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < value)
            {
                if (result == -1 || arr[i] > arr[result])
                {
                    result = i;
                }
            }
        }
        return result;
    }
