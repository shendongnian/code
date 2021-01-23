    public class Employee : INotifyPropertyChanged 
    {
        private string myUrl;
        private string myUrl2;
        public string MyUrl
        {
            get { return myUrl; }
            set
            {
                _name = value;
                RaisePropertyChanged("MyUrl");
            }
        }
        public string MyUrl2
        {
            get { return myUrl2; }
            set
            {
                _organization = value;
                RaisePropertyChanged("MyUrl2");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
