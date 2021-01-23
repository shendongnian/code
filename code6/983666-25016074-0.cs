    long size1 = GetArrayElementsSizeInMemory(new int[] { 1, 2 }); // 8 bytes
    long size2 = GetArrayElementsSizeInMemory(new int[,] { { 1 }, { 2 }, { 3 } }); // 12 bytes
    long size3 = GetArrayElementsSizeInMemory(new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } }); // 16 bytes
    //...
    static long GetArrayElementsSizeInMemory(Array array) {
        return array.Length * GetArrayElementSize(array);
    }
    static long GetArrayElementSize(Array array) {
        var elemenType = array.GetType().GetElementType();
        return elemenType.IsValueType ? Marshal.SizeOf(elemenType) : IntPtr.Size;
    }
