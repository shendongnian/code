    public class Sample : INotifyPropertyChanged
    {
        private string input = string.Empty;
        public string Input
        {
            get
            {
                return input;
            }
            set
            {
                input = value;
                NotifyPropertyChanged("Input");
                InputChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
