    class A()
    {
        IVIClass ivi = new IVIClass();
        public A(string address)
        {        
            ivi.Initialize(address);
        }
        public void SendCommand(string cmd)
        {
            ivi.Send(cmd);
        }
    }
