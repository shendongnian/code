        public MainWindowViewModel()
        {
            TestCommand = new DelegateCommand(Test, CanTest);
            ActionCommand = new DelegateCommand(async () => 
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                });
                TestCommand.RaiseCanExecuteChanged();
            });
        }
