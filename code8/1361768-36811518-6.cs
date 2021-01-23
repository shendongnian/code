    public class ViewModel : INotifyPropertyChanged
    {
        private double _doubleValue = 0;
        public double DoubleValue
        {
            get { return _doubleValue; }
            set
            {
                _doubleValue = value;
                PropertyChanged?.Invoke(this, 
                    new PropertyChangedEventArgs(nameof(DoubleValue)));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
