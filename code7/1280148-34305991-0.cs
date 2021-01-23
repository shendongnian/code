    class BaseClass
    {
        IVIClass ivi = new IVIClass();
        public void SendCommand(string cmd)
        {
            ivi.Send(cmd);
        }
    }
    
    class A : BaseClass
    {   
        public A()
        {
            string address = "1111";
            ivi.Initialize(address);
        }
    }
    
    class B : BaseClass
    {   
        public B()
        {
            string address = "2222";
            ivi.Initialize(address);
        }
    }
