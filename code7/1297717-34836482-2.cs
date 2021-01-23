    public class TextCell : INotifyPropertyChanged
    {
        private string _txtbx;
    
        public String txtbx
        {
            get { return _txtbx; }
            set
            {
                _txtbx = value;
                OnPropertyChanged();
            }
        }
    
        public TextCell()
        {
            txtbx = "sdbjshfk";
        }
    
        public override string ToString()
        {
            return txtbx;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
