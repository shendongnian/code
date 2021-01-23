     /// <summary>
    /// a first window data context, provides data to the second window based on a
    ///  ICanProvideDataForSecondWindow implementation
    /// </summary>
    public class FirstWindowDataContext:BaseObservableObject, ICanProvideDataForSecondWindow
    {
        private string _text;
        private ICommand _command;
        private bool _isSecondWindowShouldBeShown;
        private ICanProvideDataForSecondWindow _canProvideDataForSecondWindow;
        public FirstWindowDataContext()
        {
            CanProvideDataForSecondWindow = this;
        }
        public ICanProvideDataForSecondWindow CanProvideDataForSecondWindow
        {
            get { return _canProvideDataForSecondWindow; }
            set
            {
                _canProvideDataForSecondWindow = value;
                OnPropertyChanged();
            }
        }
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged();
                OnSecondWindowDataEventHandler(new DataForSecondWindowArgs{Data = Text});
            }
        }
        public ICommand Command
        {
            get { return _command ?? (_command = new RelayCommand(ShowSecondWindow)); }
        }
        //method to show the second window
        private void ShowSecondWindow()
        {
            //will show the window if it isn't opened yet
            if(IsSecondWindowShouldBeShown) return;
            IsSecondWindowShouldBeShown = true;
        }
        public bool IsSecondWindowShouldBeShown
        {
            get { return _isSecondWindowShouldBeShown; }
            set
            {
                _isSecondWindowShouldBeShown = value;
                OnPropertyChanged();
            }
        }
        public event EventHandler<DataForSecondWindowArgs> SecondWindowDataEventHandler;
        protected virtual void OnSecondWindowDataEventHandler(DataForSecondWindowArgs e)
        {
            var handler = SecondWindowDataEventHandler;
            if (handler != null) handler(this, e);
        }
    }
