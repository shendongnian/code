    public class Screenshot : ViewModelBase
    {
        private BitmapImage _screenImage;
        public BitmapImage ScreenImage
        {
            get { return _screenImage; }
            set
            {
                _screenImage = value;
                OnPropertyChanged();
            }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public Screenshot(BitmapImage screenImage, string name)
        {
            this.ScreenImage = screenImage;
            this.Name = name;
        }
        public Screenshot PerformDeepCopy()
	    {
			Screenshot deepCopy = (Screenshot)this.MemberwiseClone();
			deepCopy.ScreenImage = new BitmapImage(this.ScreenImage.UriSource);
			return deepCopy;
	    }
    }
