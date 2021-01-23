    class ClassA : System.IDisposable
    {
        IntPtr memPtr = Marshal.AllocHGlobal(1024);
        Stream memStream = new MemoryStream(1024);
        	
        public ClassA()
        {
            Console.WriteLine("Construct Class A");
        }
        
        ~ClassA()
        {
            Console.WriteLine("Finalize Class A");
            this.Dispose(false);
        }
        
        public void Dispose()
        {
            Console.WriteLine("Dispose()");
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        public void Dispose(bool disposing)
        {
            Console.WriteLine("Dispose({0})", disposing.ToString());
            if (!this.IsDisposed)
            {
                if (disposing)
                {
                    Console.WriteLine("Dispose managed objects");
                    memStream.Dispose();
                }
                Console.WriteLine("Dispose unmanaged objects");
                Marshal.FreeHGlobal(memPtr);				
            }
        }
        public bool IsDisposed { get { return this.memPtr == null; } }
    }
