    public static class ExtensionMethods
    {
        /// <summary>Swaps two bytes in a byte array</summary>
        /// <param name="buf">The array in which elements are to be swapped</param>
        /// <param name="i">The index of the first element to be swapped</param>
        /// <param name="j">The index of the second element to be swapped</param>
        public static void SwapBytes(this byte[] buf, int i, int j)
        {
            byte temp = buf[i];
            buf[i] = buf[j];
            buf[j] = temp;
        }
    }
