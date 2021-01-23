    class MainWindowViewModel : ViewModelBase
    {
        private Bitmap Img; 
        public ICommand OpenImg { get; set; }
        public MainWindowViewModel()
        {
            OpenImg = new RelayCommand(openImg, (obj) => true);
        }       
        private void openImg(object obj = null)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png;*.bmp;*.tiff|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                ImgPath = op.FileName;
                Img = new Bitmap(ImgPath);
            }
        }
        private string _ImgPath;
        public string ImgPath
        {
            get
            {
                return _ImgPath;
            }
            set
            {
                _ImgPath = value;
                OnPropertyChanged("ImgPath");
            }
        }
        private ICommand _mouseMoveCommand;
        public ICommand MouseMoveCommand
        {
            get
            {
                if (_mouseMoveCommand == null)
                {
                  _mouseMoveCommand = new RelayCommand(param => ExecuteMouseMove((MouseEventArgs)param));
                }      
                return _mouseMoveCommand;
            }
            set { _mouseMoveCommand = value; }
        }
        private void ExecuteMouseMove(MouseEventArgs e)
        {
            System.Windows.Point p = e.GetPosition(((IInputElement)e.Source));
            XY = String.Format("X: {0} Y:{1}", (int)p.X, (int)p.Y);
            BitmapData bd = Img.LockBits(new Rectangle(0, 0, Img.Width, Img.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* ptr = (byte*)bd.Scan0;
                int x = (int)p.X * 3;
                int y = (int)p.Y * bd.Stride;
                RGB = "R: "+ptr[x + y + 2].ToString() + " G: " + ptr[x + y + 1].ToString() + " B: " + ptr[x + y].ToString();
            }
            Img.UnlockBits(bd);
        }
        private string xy;
        public string XY
        {
            get { return xy; }
            set
            {
                xy = value;
                OnPropertyChanged("XY");
            }
        }
        private string rgb;
        public string RGB
        {
            get { return rgb; }
            set
            {
                rgb = value;
                OnPropertyChanged("RGB");
            }
        }
    }
