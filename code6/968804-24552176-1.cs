    public class MasterRentalType : EntityBase, INotifyPropertyChanged 
    {
        private string _RentalTypeId;
        private string _RentalTypeName;
        public string RentalTypeId
        {
            get { return _RentalTypeId; }
            set
            {
                _RentalTypeId = value;
                NotifyPropertyChanged("RentalTypeId");
            }
        }
        public string RentalTypeName
        {
            get { return _RentalTypeName; }
            set
            {
                _RentalTypeName = value;
                NotifyPropertyChanged("RentalTypeName");
            }
        }
        
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
