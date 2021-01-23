        public class A
        {
            private IBlockBlob _blockBlob;
            public A(IBlockBlob blockBlob)
            {
                _blockBlob = blockBlob;
            }
            public void ReadBlock()
            {
                _blockBlob.DoSomething();
            }
        }
