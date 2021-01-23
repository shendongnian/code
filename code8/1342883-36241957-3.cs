    public class TestImplObj : IDisposable
    {
        public TestImplObj()
        {
             //Setup test
        }
    
        public void TestImpl(int i)
        {
            //Do the actual test
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Do the clean up here
            }
        }
    }
