    [DllImport("libmat.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]        
    private static extern IntPtr matGetDir(IntPtr matFile, ref int num);
    public static string[] matGetDir(IntPtr matFile)
    {
        // Obtain as IntPtr
        var count = 0;
        var pointers = matGetDir(matFile, ref count);
        // Cast into IntPtr[]
        var ptrs = new IntPtr[count];
        Marshal.Copy(pointers, ptrs, 0, count);
        // Convert each value in IntPtr[] into string
        // NB: using System.Linq;
        return ptrs.Select(x => Marshal.PtrToStringAnsi(x)).ToArray();
    }
