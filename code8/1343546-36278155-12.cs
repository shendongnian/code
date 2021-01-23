        public class A
        {
            private readonly IFactoryBlockBlob _blobFctory;
            public A(IFactoryBlockBlob blobFctory)
            {
                _blobFctory = blobFctory;
            }
            public void ReadBlock()
            {
               var blob =  _blobFctory.Create();
            }
        }
