    class ViewModel : INotifyPropertyChanged
    {
        private string _test;
        public string TestValue
        {
            get { return _test; }
            set { _test = value; RaisePropertyChanged("TestValue"); }
        }
        public ICommand MyCommand { get; internal set; }
        public ViewModel()
        {
            TestValue = "Test";
            CreateTestCommand();
        }
        private void CreateTestCommand()
        {
            MyCommand = new TestCommand(ExecuteButton);
        }
        private void ExecuteButton(object obj)
        {
            TestValue = "Cool";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propName)
        {
            var pc = PropertyChanged;
            if (pc != null)
            {
                pc(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
