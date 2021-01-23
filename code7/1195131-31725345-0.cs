    public static void Main()
    {
    	Console.WriteLine(String.Join(", ", headandtail(new int[]{1, 2, 3})));
    	Console.WriteLine(String.Join(", ", headandtail(new int[]{1, 2, 3, 4, 5, 6})));
    	Console.WriteLine(String.Join(", ", headandtail(new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11})));
    }
    
    private static T[] headandtail<T>(T[] src) {
    	int runlen = Math.Min(src.Length, 5);
        T[] result = new T[2 * runlen];
        Array.Copy(src, 0, result, 0, runlen);
        Array.Copy(src, src.Length - runlen, result, result.Length - runlen, runlen);
        return result;
    }
