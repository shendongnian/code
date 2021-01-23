    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    
    public class Category : INotifyPropertyChanged
    {
        #region Properties
        private int _Id;
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id == value)
                    return;
                _Id = value;
                OnPropertyChanged();
            }
        }
    
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name == value)
                    return;
                _Name = value;
                OnPropertyChanged();
            }
        }
        #endregion
    
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
