    using System;
    using System.Runtime.InteropServices;
    
    namespace BitmapProcessingCs
    {
        public static class NativeMethods
        {
            [DllImport("BitmapProcessingCpp.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void GenerateBitmap(IntPtr src, int dimension);
        }
    }
