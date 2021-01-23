    public class MainViewModel : ViewModelBase
    {
        public string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
                RaisePropertyChanged(() => ImagePath);
            }
        }
        private string _imagePath;
        public RelayCommand ImageCommand
        {
            get
            {
                return _imageCommand ??
                    (_imageCommand = new RelayCommand(() => ImagePath = "Image.png"));
            }
        }
        private RelayCommand _imageCommand ;
        public MainViewModel()
        {
            // I've tried both of those and it still works
            //ImagePath = "";
            //ImagePath = null;
        }
    }
