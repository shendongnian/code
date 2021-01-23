    public class Day : INotifyPropertyChanged
    {
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Date"));
            }
        }
        private ICollectionView scenes;
        public ICollectionView Scenes
        {
            get { return scenes; }
            set
            {
                scenes = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Scenes"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
