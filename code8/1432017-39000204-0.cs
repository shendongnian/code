    public class Model : INotifyPropertyChanged
    {
        private string _myProperty;
        public string MyProperty
        {
            get { return _myProperty; }
            set
            {
                _myProperty = value;
                RaisePropertyChanged();
            }
        }
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            Volatile.Read(ref PropertyChanged)?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
