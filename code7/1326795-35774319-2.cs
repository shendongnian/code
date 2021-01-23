    internal class MyChild : MarshalByRefObject, IChild
    {
        private DomainHost host;
        public void Initialize(DomainHost host)
        {
            // store the remote host here so you will able to use it to send feedbacks
            this.host = host;
            host.SendMessage(this, "I am being initialized.")
        }
        public string Name { get { return "Dummy child"; } }
        public void DoSomeChildishJob()
        {
            host.SendMessage(this, "Job started.")
            host.SendObject(this, 42);
            host.SendMessage(this, "Job finished.")
        }
    }
