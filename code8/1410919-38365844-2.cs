    public class MainPageViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        public WriteableBitmap _original;
        public WriteableBitmap Original
        {
            get { return this._original; }
            set
            {
                this._original = value;
                RaisePropertyChanged("Original");
            }
        }
        public MainPageViewModel()
        { }
        public MainPageViewModel(WriteableBitmap original)
        {
            this.Original = original;
        }
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
