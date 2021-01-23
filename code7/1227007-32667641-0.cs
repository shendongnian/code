    public struct SomeStruct
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7*12)]
        public float[] matrix;
    }
