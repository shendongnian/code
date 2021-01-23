    public class Test
    {
        private byte[] someArray;
        public Test()
        {
            this.someArray = new byte[1];
        }
        public void DoMarshal()
        {
            GCHandle handle = GCHandle.Alloc( this.someArray, GCHandleType.Pinned );
            try
            {
                // Prints a non-zero address, like '650180924952'.
                Console.Out.WriteLine( handle.AddrOfPinnedObject().ToString() );
            }
            finally
            {
                handle.Free();
            }
        }
    }
