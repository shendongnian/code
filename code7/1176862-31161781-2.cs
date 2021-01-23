    class LockingWithAwait
    {
        public async void Test()
        {
            await Task.Run(() => DoSomethingLong());
            ShowMessageBox();
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
