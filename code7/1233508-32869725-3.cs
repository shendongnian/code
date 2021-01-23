    public class SecondViewModel : INotifyPropertyChanged
    {
        private readonly Second model;
        private bool _isExpanded;
        public SecondViewModel(Second second)
        {
            model = second;
        }
        public int SecondNumber
        {
            get
            {
                return model.Number;
            }
            set
            {
                model.Number = value;
                NotifyPropertyChanged();
            }
        }
        //Added property to avoid warnings in output window
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                _isExpanded = value;
                NotifyPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
