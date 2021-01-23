    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<DataItem> _dataItems = new ObservableCollection<DataItem>();
        public ObservableCollection<DataItem> DataItems { get { return _dataItems; } }
        private TestCommand _scrollCommand;
        public ICommand ScrollCommand { get { return _scrollCommand; } }
        public string ScrollData { get; set; }
        public MainWindowViewModel()
        {
            for (int i = 0; i < 100; i++)
            {
                _dataItems.Add(new DataItem() { Field1 = i.ToString(), Field2 = (i * 2).ToString(), Field3 = (i * 3).ToString() });
            }
            _scrollCommand = new TestCommand(OnScroll);
        }
        private void OnScroll(object param)
        {
            ScrollChangedEventArgs args = param as ScrollChangedEventArgs;
            if (args != null)
            {
                ScrollData = $"VerticalChange = {args.VerticalChange}; VerticalOffset = {args.VerticalOffset}";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScrollData)));
            }
        }
    }
    public class DataItem
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
    }
    public class TestCommand : ICommand
    {
        private Action<object> _execute;
        public event EventHandler CanExecuteChanged;
        public TestCommand(Action<object> execute)
        {
            _execute = execute;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
