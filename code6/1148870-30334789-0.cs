         /// <summary>
         /// Represents a test validation result.
         /// </summary>
        internal class Test : INotifyPropertyChanged
        {
       
        private string _imgstring = string.Empty;
        public string ImageString
        {
            get
            {
                return _imgstring;
            }
            set
            {
                _imgstring = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("ImageString");
            }
        }
        
      }
