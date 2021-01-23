    public class YourClassName : INotifyPropertyChanged
    {
        // These fields hold the values for the public properties.
        private Employee _selectedEmployee;
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    
        // The constructor is private to enforce the factory pattern.
        private YourClassName()
        {
            _selectedEmployee = new Employee();
        }
       
        public Employee selectedEmployee
        {
            get
            {
                return this._selectedEmployee;
            }
			set
            {
                if (value != this._selectedEmployee)
                {
                    this._selectedEmployee = value;
                    NotifyPropertyChanged("selectedEmployee");
                }
            }
        }
    }
