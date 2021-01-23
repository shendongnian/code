    class LockingWithAwait
    {
        public void Test()
        {
            DoSomething();
        }
        private async void DoSomething()
        {
            await Task.Run(() => DoSomethingLong());
            ShowMessageBox();
        }
        private async void DoSomethingLong()
        {
            Console.WriteLine("Doing somthing.");
            Thread.Sleep(10000);
        }
        private void ShowMessageBox()
        {
            Console.WriteLine("Hello world.");
        }
    }
