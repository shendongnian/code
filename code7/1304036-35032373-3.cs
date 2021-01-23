     public class Row : INotifyPropertyChanged
     {
      
        private string _text;
        public String Text
        {
            get
            {               
                return _text;
            }
            set
            {
                _text = value;                
                IsChanged = true;
                this.OnPropertyChanged("Text");
            }
        }
         
            private bool _isChanged;
        public bool IsChanged
        {
            get
            {
                return _isChanged;
            }
            set
            {
                _isChanged = value;
                this.OnPropertyChanged("IsChanged");
            }
        }
         #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler eh = this.PropertyChanged;
            if (null != eh)
            {
                eh(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion
     }
