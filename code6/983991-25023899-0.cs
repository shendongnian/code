    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Brush textColor = Brushes.Red;
        public Brush TextColor
        {
            get { return textColor; }
            set
            {
                textColor = value;
                RaisePropertyChanged("TextColor");
            }
        }
        private void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
