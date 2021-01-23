    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Changetopicone = new RelayCommand(param => piconevoid());
            Changetopictwo = new RelayCommand(param => pictwovoid());
            LogoSourcePath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        }
        private void piconevoid()
        {
            PicturePath = LogoSourcePath + @"\pic1.png";
        }
        private void pictwovoid()
        {
            PicturePath = LogoSourcePath + @"\pic2.png";
        }
        public string LogoSourcePath { get; set; }
        private string _picturepath;
        public string PicturePath
        {
            get { return _picturepath; }
            set
            {
                _picturepath = value;
                NotifyPropertyChanged("PicturePath");
            }
        }
        public ICommand Changetopicone
        {
            get;
            set;
        }
        public ICommand Changetopictwo
        {
            get;
            set;
        }
    }
