    public class Form2 : Form, INotifyPropertyChanged
    {
        public int latestresult2;
        public event PropertyChangedEventHandler PropertyChanged;
        public static string LatestResult2
        {
            get
            {
                return latestresult2;
            }
            set
            {
                latestresult2 = value;
                this.OnPropertyChanged("LatestResult2");
            }
        }
        private virtual void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler == null)
            {
                return;
            }
            handler(this, new PropertyChangedEventArgs(propertyName));
       }
    }
    public class Form3 : Form, INotifyPropertyChanged
    {
        public int latestResult3;
        public event PropertyChangedEventHandler PropertyChanged;
        public static string LatestResult3
        {
            get
            {
                return latestresult3;
            }
            set
            {
                latestresult3 = value;
                this.OnPropertyChanged("LatestResult3");
            }
        }
        private virtual void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler == null)
            {
                return;
            }
            handler(this, new PropertyChangedEventArgs(propertyName));
       }
    }
