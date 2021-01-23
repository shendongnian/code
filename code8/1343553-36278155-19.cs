        public class A
        {
            public void ReadBlock()
            {
                ReadBlock(new CloudBlockBlob(<the params bla bla...>));
            }
            internal void ReadBlock(ICloudBlob blob)
            {
            }
        }
