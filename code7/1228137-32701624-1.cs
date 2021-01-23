    public interface IMainWindowViewModel
    {
        string Arguments { get; set; }
    }
    public class MainWindowViewModel : IMainWindowViewModel, INotifyPropertyChanged
    {
        private string _arguments;
        public MainWindowViewModel(string argumentsInfo)
        {
            Arguments = argumentsInfo;
        }
        public string Arguments
        {
            get { return _arguments; }
            set
            {
                _arguments = value;
                RaisePropertyChanged("Arguments");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate {};
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
