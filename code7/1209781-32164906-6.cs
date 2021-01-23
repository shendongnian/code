    public class ViewModel : INotifyPropertyChanged
    {
        FrameworkElement _myUc;
        public FrameworkElement MyUserControl
        {
            get
            {
                return _myUc;
            }
            set
            {
                _myUc= value;
                OnPropertyChanged("MyUserControl");
            }
        }
    
        public ViewModel()
        {
            OpenCommand = new RelayCommand(Open);
        }
        public void Open(object sender)
        {
            if (sender.ToString() == "btnHistory")
            {
               MyUserControl = objHistory;
            }
        }
        // rest of your view model ...
    }
