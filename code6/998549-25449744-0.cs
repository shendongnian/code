    [Serializable]
    [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)] 
    [System.Runtime.InteropServices.ComVisible(true)]
        public struct Int32 : IComparable, IFormattable, IConvertible
            , IComparable<Int32>, IEquatable<Int32>
            , IArithmetic<Int32> {
            internal int m_value; // <<== Here it is
        
            public const int MaxValue = 0x7fffffff;
            public const int MinValue = unchecked((int)0x80000000);
            ...
    }
