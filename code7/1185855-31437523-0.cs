    public class A
    {
        private B _b;
        
        public A(B b)
        {
            _b = b;
        }
        void UseData()
        {
            _b.GetData();
        }
    }
    
    Public class B
    {
        public DataView GetData();
    }
