    private static int[] A000043 = new int[] { 2, 3, 5, 7, 13, 17, 19, 31 };
    private static int[] A000668 = new int[] { 3, 7, 31, 127, 8191, 131071, 524287, 2147483647 };
    
    public static bool IsInA000668(int value) => A000668.Contains(value);
    public static bool IsInA000043(int value) => A000043.Contains(value);
