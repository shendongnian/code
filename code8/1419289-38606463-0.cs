    public class ImageListFixed : INotifyPropertyChanged
        {
            #region Fields
        private ObservableCollection<ImageItem> images = new ObservableCollection<ImageItem>();
        private int selectedIndex;
        private ImageItem currentImage;
        #endregion Fields
        
        #region Properties
        public ObservableCollection<ImageItem> Images
        {
            get { return images; }
            set { images = value; }
        }
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if(value < Images.Count && value > -1)
                {
                    selectedIndex = value; OnPropertyChanged();
                    CurrentImage = Images[selectedIndex];
                }
            }
        }
        public ImageItem CurrentImage
        {
            get { return currentImage; }
            set { currentImage = value; OnPropertyChanged(); }
        }
        #endregion Properties
        #region Public Methods
        public void Next()
        {
            SelectedIndex ++;
        }
        public void Back()
        {
            SelectedIndex--;
        }
        #endregion Public Methods
        #region Methods
        public void AddNewImage()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.gif, *.png, *.bmp, *.tif) | *.jpg; *.jpeg; *.jpe; *.gif; *.png, *.bmp, *.tif";
            dlg.ShowDialog();
            if(dlg.FileName != "")
            {
                Images.Add(new ImageItem() { URI = new Uri(dlg.FileName) });
                SelectedIndex = Images.Count - 1;
            }
        }
        #endregion Methods
        #region Constructors
        public ImageListFixed()
        {
            _canExecute = true;
        }
        #endregion Constructors
        #region Commands
        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => AddNewImage(), _canExecute));
            }
        }
        
        private bool _canExecute;
        private ICommand nextCommand;
        public ICommand NextCommand
        {
            get
            {
                if (nextCommand == null)
                {
                    nextCommand = new CommandHandler(()=> OnNextCommand(), true);
                }
                return nextCommand;
            }
            set { nextCommand = value; }
        }
        private void OnNextCommand()
        {
            Next();
        }
        private ICommand backCommand;
        public ICommand BackCommand
        {
            get
            {
                if(backCommand == null)
                {
                    backCommand = new CommandHandler(() => OnBackCommand(), true);
                }
                return backCommand;
            }
            set { backCommand = value; }
        }
        private void OnBackCommand()
        {
            Back();
        }
        #endregion Commands
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged
    }`
