    public class A
    {
        IBlockBlob _blockBlob
    
        public A(IBlockBlob blockBlob)
        {
            _blockBlob = blockBlob;
        }
    
        public void ReadBlock()
        {
            _blockBlob.DoSomething();
        }
    }
