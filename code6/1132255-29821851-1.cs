    //using System.ComponentModel;
    
    public class MyClass : INotifyPropertyChanged
    {
        private string _subjLastName;
    
        ///<summary>
        /// public lastname property
        ///</summary>
        public string SubjLastName
        {
            get
            {
                return _subjLastName;
            }
            set
            {
                // The if statement here is importent! So you only raise the notification if the value has changed
                if (_subjLastName != value)
                {
                    _subjLastName = value;
                    OnPropertyChanged("SubjLastName");
                }
            }
        }
    
        #region INotify
    
        #region OnPropertyChanged + Handler
    
        ///<summary>
        /// PropertyChanged event handler
        ///</summary>
        public event PropertyChangedEventHandler PropertyChanged;
    
        ///<summary>
        /// Notify the UI for changes
        ///</summary>
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    
        #endregion
    }
