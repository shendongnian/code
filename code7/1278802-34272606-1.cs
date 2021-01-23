    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DelegateCommand _scrollCommand = new DelegateCommand();
        public ICommand ScrollCommand { get { return _scrollCommand; } }
        public MainWindowViewModel()
        {
        }
    }
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            MessageBox.Show("fired");
        }
    }
