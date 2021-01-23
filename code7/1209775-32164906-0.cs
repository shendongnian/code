    public class ViewModel : INotifyPropertyChanged
    {
        FrameworkElement _element;
        public FrameworkElement Element
        {
            get
            {
                return _element;
            }
            set
            {
                _element = value;
                OnPropertyChanged("Element");
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
               Element = objHistory;
            }
        }
        // rest of your view model ...
    }
