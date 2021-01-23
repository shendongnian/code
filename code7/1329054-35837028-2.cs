    Task.Factory.StartNew(() =>
        {
            System.Threading.Thread.Sleep(5000);
            CallMethod();
        });
