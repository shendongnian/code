    public static void InsertByte2(byte[] array, int index, byte value)
    {
        Array.Copy(array, index, array, index + 1, a.Length - index - 1);
        array[index] = value;
    }
