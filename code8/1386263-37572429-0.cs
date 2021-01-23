    class Wait: Form
    {
        public Wait() : base() 
        {
            System.Threading.Tasks.Task.Factory.StartNew(() => VerifyFile());
        }
    }
