    class MyViewModel : INotifyPropertyChanged
    {
        // The compiler will complain about this:
        // Warning 3 The event 'MyNamespace.MyViewModel.PropertyChanged' is never used
        public event PropertyChangedEventHandler PropertyChanged;
        private string _myProp;
        public string MyProp
        {
            get { return _myProp; }
            set
            {
                _myProp = value;
                this.Notify(this.PropertyChanged);
            }
        }
    }
