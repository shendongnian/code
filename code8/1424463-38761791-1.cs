    public class Container : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool selected;
        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Selected"));
            }
        }
        ...
    }
