    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MyViewModel()
        {
        }
        private string myIcon;
        public string MyIcon
        {
            get { return myIcon; }
            set
            {
                if (value != myIcon)
                {
                    myIcon = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private Visual myResource;
        public Visual MyResource
        {
            get { return myResource; }
            set
            {
                if (value != myResource)
                {
                    myResource = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
