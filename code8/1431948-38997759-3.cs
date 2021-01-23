    public class Viewmodel : INotifyPropertyChanged
    {
        private Visibility vis;
        public Visibility whateverName
        {
            get { return vis; }
            set
            {
                vis = value;
                OnPropertyChanged("whateverName");
            }
        }
        public void OnPropertyChanged(string pName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pName));
        }
            
        public event PropertyChangedEventHandler PropertyChanged;
    }
