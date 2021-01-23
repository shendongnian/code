    public static int[] SingleIndexToMulti(int index, int[] dimentionSizes)
    {
        var result = new int[dimentionSizes.Length];
        for (int i = dimentionSizes.Length - 1; i >=0; i--)
        {
            result[i] = index % dimentionSizes[i];
            index = index / dimentionSizes[i];
        }
        return result;
    }
