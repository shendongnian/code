    public class EmployeeModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool inBuilding;
        public bool InBuilding
        {
            get { return inBuilding; }
            set
            {
                if (inBuilding != value)
                {
                    inBuilding = value;
                    OnPropertyChanged("InBuilding");
                }
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        ...
    }
