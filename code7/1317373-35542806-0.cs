    public static class FortranLib
    {
        private const string _dllName = "FortranLib.dll";
 
        [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DoStuff([In] double[] vector, ref int n, [In, Out] double[,] matrix);
    }
