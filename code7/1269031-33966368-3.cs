    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    class ViewModel : INotifyPropertyChanged
    {
        private readonly ICommand _command;
        private string _text = string.Empty;
        public ICommand Command { get { return _command; } }
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    OnPropertyChanged();
                }
            }
        }
        public ViewModel()
        {
            _command = new DelegateCommand<object>(ExecuteCommand);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void ExecuteCommand(object parameter)
        {
            Text = new string(Text.Reverse().ToArray());
        }
    }
    class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> _handler;
        private readonly Func<T, bool> _canExecute;
        public DelegateCommand(Action<T> handler) : this(handler, null) { }
        public DelegateCommand(Action<T> handler, Func<T, bool> canExecute)
        {
            _handler = handler;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            _handler((T)parameter);
        }
        public void OnCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
