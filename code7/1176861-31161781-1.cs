    class LockingWithTPL
    {
        public void Test()
        {
            Task.Factory.StartNew(DoSomethingLong).ContinueWith(result => ShowMessageBox());
        }
        private void DoSomethingLong()
        {
            Console.WriteLine("Doing somthing.");
            Thread.Sleep(1000);
        }
        private void ShowMessageBox()
        {
            Console.WriteLine("Hello world.");
        }
    }
