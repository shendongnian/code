    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            PreviousImageCommand = new RelayCommand(PreviousImage);
            NextImageCommand = new RelayCommand(NextImage);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand PreviousImageCommand { get; set; }
        public ICommand NextImageCommand { get; set; }
        public List<ImageSource> Images { get; set; }
        public ImageSource CurrentImage
        {
            get
            {
                if (currentImageIndex < Images.Count)
                {
                    return Images[currentImageIndex];
                }
                return null;
            }
        }
        private int currentImageIndex;
        private void PreviousImage(object o)
        {
            if (Images.Count > 0)
            {
                // add Image.Count to avoid negative index
                currentImageIndex = (currentImageIndex + Images.Count - 1) % Images.Count;
                OnPropertyChanged("CurrentImage");
            }
        }
        private void NextImage(object o)
        {
            if (Images.Count > 0)
            {
                currentImageIndex = (currentImageIndex + 1) % Images.Count;
                OnPropertyChanged("CurrentImage");
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
