    public class InputMessageBoxProperties:INotifyPropertyChanged
    {
        
        private int _width  ;     
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (_width == value)
                {
                    return;
                }
                _width = value;
                OnPropertyChanged();
            }
        }
      // add the other properties following the same pattern 
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
 
