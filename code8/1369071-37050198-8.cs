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
    public interface ICanProvideDataForSecondWindow
    {
        event EventHandler<DataForSecondWindowArgs> SecondWindowDataEventHandler;
        string Text { get; set; }
    }
    public class DataForSecondWindowArgs:EventArgs
    {
        public string Data { get; set; }
    }
    /// <summary>
    /// second window data context, listening for the changes in first window data context to show them on the second window
    /// </summary>
    class SecondWindowDataContext:DisposableBaseObservableObject
    {
        private readonly ICanProvideDataForSecondWindow _canProvideDataForSecondWindow;
        private string _text;
        public SecondWindowDataContext(ICanProvideDataForSecondWindow canProvideDataForSecondWindow)
        {
            _canProvideDataForSecondWindow = canProvideDataForSecondWindow;
            _canProvideDataForSecondWindow.SecondWindowDataEventHandler += CanProvideDataForSecondWindowOnSecondWindowDataEventHandler;
            Text = _canProvideDataForSecondWindow.Text;
        }
        private void CanProvideDataForSecondWindowOnSecondWindowDataEventHandler(object sender, DataForSecondWindowArgs args)
        {
            Text = args.Data;
        }
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }
        protected override void DisposeOverride()
        {
            base.DisposeOverride();
            _canProvideDataForSecondWindow.SecondWindowDataEventHandler -= CanProvideDataForSecondWindowOnSecondWindowDataEventHandler;
        }
    }
