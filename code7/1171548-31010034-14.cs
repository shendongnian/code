    public class Form2 : Form, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static string latestresult2
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
