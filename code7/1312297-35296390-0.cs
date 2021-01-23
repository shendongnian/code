    public class Item : INotifyPropertyChanged
    {
        private Uri thumbnail;
        public Uri Thumbnail
        {
            get { return thumbnail; }
            set
            {
                thumbnail = value;
                NotifyPropertyChanged("Thumbnail");
            }
        }
    
        private SolidColorBrush buttonColor = new SolidColorBrush(Color.FromArgb(255, 178, 178, 178));
        public SolidColorBrush ButtonColor
        {
            get { return buttonColor; }
            set
            {
                buttonColor = value;
                NotifyPropertyChanged("ButtonColor");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
