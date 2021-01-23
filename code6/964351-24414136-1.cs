    class Program
    {
        void ExampleUsage()
        {
            var buf = new byte[] {4, 1, 168, 192};
            buf.SwapBytes(0, 1);
            buf.SwapBytes(2, 3);
        }
    }
