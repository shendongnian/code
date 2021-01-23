    public class DisplayItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ImageSource icon;
        public ImageSource Icon
        {
            get
            {
                if (icon == null)
                {
                    icon = ... // load here
                }
                return icon;
            }
            private set
            {
                icon = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Icon"));
            }
        }
    }
