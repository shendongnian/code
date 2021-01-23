    public abstract DialogViewModelBase : ViewModelBase
    {
        private bool? _dialogResult;
        public event EventHandler Closing;
        public string Title {get; private set;}
        public ObservableCollection<DialogButton> DialogButtons { get; }
        public bool? DialogResult
        {
            get { return _dialogResult; }
            set { SetProperty(ref _dialogResult, value); }
        }
        public void Close()
        {
            Closing?.Invoke(this, EventArgs.Empty);
        }
    }
