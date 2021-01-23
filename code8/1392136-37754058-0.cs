    public class Mining : INotifyPropertyChanged
    {
        public static int _iron
        public int iron
        {
            get { return _iron; }
            set
            {
                _iron = value;
                OnPropertyChanged("iron");
            }
        }
        public void mine_iron_Click(object sender, RoutedEventArgs e)
        {
            iron++;
        }
        protected void OnPropertyChanged(string Name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(Name));
            }
        }
    }
