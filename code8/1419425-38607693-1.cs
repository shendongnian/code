    public static void InsertByte(byte[] array, int index, byte value)
    {
        // shifting all bytes one spot. (from back to front)
        for (int i = array.Length - 1; i > index; i--)
            array[i] = array[i - 1];
        // assigning the new value
        array[index] = value;
    }
