    //test interface and test class
    public interface IProvidePropertyToBindTo
    {
        string GetPropertyToBindTo();
    }
    public class TestChoosingPropertyToBind : IProvidePropertyToBindTo, INotifyPropertyChanged
    {
        #region Fields
        public event PropertyChangedEventHandler PropertyChanged;
        private string _emailAddress;
        private string _name;
        private string _propertyName;
        #endregion Fields
        #region Properties
        public string EmailAddress
        {
            get { return _emailAddress; }
            set
            {
                if (_emailAddress == value) 
                    return;
                _emailAddress = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;
                _name = value;
                OnPropertyChanged();
            }
        }
        public string PropertyToBindTo
        {
            set { SetPropertToBindTo(value); }
        }
        #endregion 
        #region Methods
        public string GetPropertyToBindTo()
        {
            return _propertyName;
        }
        public void SetPropertToBindTo(string propertyName)
        {
            var prop = GetType().GetProperty(propertyName);
            if (prop == null)
                throw new Exception("Property : "+propertyName+" does not exist in this object {"+this.ToString()+"}.");
            _propertyName = propertyName;
        }
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion Methods
    }
