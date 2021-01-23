    private bool ArrayMaking(int[] array1, int[] array2, int value, out int[] arrays)
    {
        int size = array1.Length + array2.Length + 1;
        arrays = new int[size];
        for (int i = 0; i < array1.Length; i++)
            arrays[i] = array1[i];
        for (int i = 0; i < array2.Length; i++)
            arrays[i + array1.Length] = array2[i];
        arrays[arrays.Length - 1] = value;
        return true;
    }
