    [DllImport("Win32Project1", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
    static unsafe extern bool GenerateItems(out ItemsSafeHandle itemsHandle,
        out double* items, out int itemCount);
    [DllImport("Win32Project1", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
    static unsafe extern bool ReleaseItems(IntPtr itemsHandle);
    static unsafe void Main()
    {
        ItemsSafeHandle itemsHandle;
        double* items;
        int itemsCount;
        if (!GenerateItems(out itemsHandle, out items, out itemsCount))
        {
            throw new InvalidOperationException();
        }
        try
        {
            double sum = 0;
            for (int i = 0; i < itemsCount; i++)
            {
                sum += items[i];
            }
            Console.WriteLine("Average is: {0}", sum / itemsCount);
        }
        finally
        {
            itemsHandle.Dispose();
        }
        Console.ReadLine();
    }
    class ItemsSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public ItemsSafeHandle()
            : base(true)
        {
        }
        protected override bool ReleaseHandle()
        {
            return ReleaseItems(handle);
        }
    }
