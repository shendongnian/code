    public class Contremarque : INotifyPropertyChanged
    {
		private bool _hasLink;      
		public bool hasLink 
        {
            get { return _hasLink; }
            set
            {
                _hasLink= value;
                OnPropertyChanged();
            }
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }           
        }
    }
