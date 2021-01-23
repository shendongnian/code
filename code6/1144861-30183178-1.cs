    [DllImport("...", CallingConvention = CallingConvention.StdCall)]
    public static extern void PopulateArray(
        [In, Out]
        [MarshalAs(MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
        int[] arr,
        ref int len
    );
    
    ....
    int[] arr = new int[50];
    int len = arr.Length;
    PopulateArray(arr, ref len);
    // len now contains actual length
