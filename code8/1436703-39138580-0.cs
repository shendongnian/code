    class AB : IAB
    {
        IA instanceA;
        IB instanceB;
        public AB(IA _a, IB _b)
        {
            instanceA = _a;
            instanceB = _b;
        }
    
        public void A()
        {
            throw new NotImplementedException();
        }
    
        public void B()
        {
            throw new NotImplementedException();
        }
    }
