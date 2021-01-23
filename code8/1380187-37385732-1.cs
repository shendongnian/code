    public static class Arrays
    {
        public static bool HaveDifferingLengths(params Array[] arrays)
        {
            return arrays.Any(a => a.Length != arrays[0].Length);
        }
    }
    ...
    if (Arrays.HaveDifferingLengths(arr1, arr2, arr3, arr4))
    {
        // Throw or whatever.
    }
