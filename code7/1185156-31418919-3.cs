    static unsafe void Main()
    {
        double* items;
        int itemsCount;
        using (GenerateItemsWrapper(out items, out itemsCount))
        {
            double sum = 0;
            for (int i = 0; i < itemsCount; i++)
            {
                sum += items[i];
            }
            Console.WriteLine("Average is: {0}", sum / itemsCount);
        }
        Console.ReadLine();
    }
    #region wrapper
    [DllImport("Win32Project1", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
    static unsafe extern bool GenerateItems(out ItemsSafeHandle itemsHandle,
        out double* items, out int itemCount);
    [DllImport("Win32Project1", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
    static unsafe extern bool ReleaseItems(IntPtr itemsHandle);
    static unsafe ItemsSafeHandle GenerateItemsWrapper(out double* items, out int itemsCount)
    {
        ItemsSafeHandle itemsHandle;
        if (!GenerateItems(out itemsHandle, out items, out itemsCount))
        {
            throw new InvalidOperationException();
        }
        return itemsHandle;
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
    #endregion
