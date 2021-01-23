    public class ZeroTest
    {
        private byte[] someArray;
        public Test()
        {
            this.someArray = null;
        }
        public void DoMarshal()
        {
            GCHandle handle = GCHandle.Alloc( this.someArray, GCHandleType.Pinned );
            try
            {
                // Prints '0'.
                Console.Out.WriteLine( handle.AddrOfPinnedObject().ToString() );
            }
            finally
            {
                handle.Free();
            }
        }
    }
