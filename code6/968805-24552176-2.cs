    public class MasterRentalModel: INotifyPropertyChanged 
    {
        private MasterRentalType _SelectedMasterRentalType;
        private List<MasterRentalType> _MasterRentalTypeColl = new List<MasterRentalType>();
        public MasterRentalType SelectedMasterRentalType
        {
            get { return _SelectedMasterRentalType; }
            set
            {
                _SelectedMasterRentalType = value;
                NotifyPropertyChanged("SelectedMasterRentalType");
            }
        }
        public List<MasterRentalType> MasterRentalTypeColl
        {
            get { return _MasterRentalTypeColl; }
            set { _MasterRentalTypeColl = value; }
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
