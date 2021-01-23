    public static int GetClosestIndex(int[] arr, int value)
    {
        int result = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < value && arr[i] > result)
            {
                result = i;
            }
        }
        return result;
    }
