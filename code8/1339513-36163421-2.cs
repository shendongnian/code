    public class MyWrapper : IDisposable
    {
        [DllImport("MyLibrary.dll")]
        private static extern IntPtr DoAllocSomeMemory(int size);
        [DllImport("MyLibrary.dll")]
        private static extern void ReleaseMe(IntPtr handle);
        private IntPtr _handle;
        public MyWrapper()
        {
            _handle = DoAllocSomeMemory(8000);
        }
        public void Dispose()
        {
            ReleaseMe(_handle);
        }    
    }
