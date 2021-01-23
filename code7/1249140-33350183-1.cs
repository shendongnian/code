    [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void mxFree(IntPtr ptr);
    [DllImport("libmat.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]        
    private static extern IntPtr matGetDir(IntPtr matFile, ref int num);
    
    public static string[] matGetDir(IntPtr matFile)
    {
        // Obtain as IntPtr
        var count = 0;
        var pointers = matGetDir(matFile, ref count);
        // Handling errors as noticed by David Heffernan
        if (count < 0) { throw new Exception("Failed to obtain list of variables in selected mat file."); }
        if (pointers == IntPtr.Zero) { return new string[0]; }
        // Cast into IntPtr[]
        var ptrs = new IntPtr[count];
        Marshal.Copy(pointers, ptrs, 0, count);
        // Convert each value in IntPtr[] into string
        // NB: using System.Linq;
        var strs = ptrs.Select(x => Marshal.PtrToStringAnsi(x)).ToArray();
        // Don't forget to free memory allocated by Matlab
        mxFree(pointers);
        // And voilà
        return strs;
    }
