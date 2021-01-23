    // Returns the SubArray starting from index and covering the amount of length items.
    public static T[] SubArray<T>(this T[] data, int index, int length)
    {
        T[] result = new T[length];
        System.Array.Copy(data, index, result, 0, length);
        return result;
    }
