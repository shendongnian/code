    class Thing
    {
        public Thing()
        {
           Command = new GalaSoft.MvvmLight.Command.RelayCommand<bool>(DoIt);
        }
        private void DoIt(bool p)
        {
           p.DoSomething(p);
        }
        public System.Windows.Input.ICommand Command { get; private set; }
    }
