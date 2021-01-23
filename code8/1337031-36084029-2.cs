    public class ViewModel : INotifyPropertyChanged
    {
        private ImageSource theImage;
        public ImageSource TheImage
        {
            get { return theImage; }
            set
            {
                theImage = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
