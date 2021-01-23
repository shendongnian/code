    public class SomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        public ICommand ImageTapCommand { get; set; }
    
    
        private string imagePath;
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ImagePath"));
            }
        }
    
        public SomeViewModel()
        {
            ImageTapCommand = new Command(CmdTapImage);
        }
    
    
        private void CmdTapImage()
        {
            ImagePath = YourNewImagePath;
        }
    }
