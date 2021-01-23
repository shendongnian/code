    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> SomeCollection { get; set; }
        public ICommand TestCommand { get; private set; }
    
        public MainWindowViewModel()
        {
            SomeCollection = new ObservableCollection<string>();
            TestCommand = new RelayCommand<object>(CommandMethod);
        }
    
        private void CommandMethod(object parameter)
        {
            SomeCollection.Add("Some dummy string");
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
