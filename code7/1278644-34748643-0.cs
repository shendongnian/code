        public class Ressource : INotifyPropertyChanged
    {
        private String _downloaded;
        public String downloaded
        {
            get { return this._downloaded; }
            set
            {
                this._downloaded = value;
                raiseProperty("downloaded");
            }
        }
            public event PropertyChangedEventHandler PropertyChanged;
        private void raiseProperty(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
