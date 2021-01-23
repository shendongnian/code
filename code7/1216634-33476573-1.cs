        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static int passArrayStrings([In, Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.BStr, SizeParamIndex = 1)]  string[] tab, int iSize)
        {
            return 1;
        }
