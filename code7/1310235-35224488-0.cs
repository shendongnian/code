    public struct My_FSet
    {
        public readonly int Num;
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 100)]
        public readonly uint[] Freqs;
        public My_FSet(int num, uint[] freqs)
        {
            this.Num = num;
            this.Freqs = freqs;
        }
    }
