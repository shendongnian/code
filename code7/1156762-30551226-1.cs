    struct Test
    {
        public int test1;
        public int test2;
    }
    [DllImport("mydll", CallingConvention = Cdecl)]
    public static extern void FillStruct( Test[] stTest, int size);
    [...]
    var test = new Test[n];
    FillStruct(test, test.Length);
