    private static int[] squareArray(int[] array)
    {
        int[] result = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            result[i] = (int)Math.Pow(array[i], 2);
        }
        return result;
    }
