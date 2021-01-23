    public class Person : INotifyPropertyChanged
    {
        private string _Name;
    
        public string Name
        {
            get { return _Name; }
            set
            {
                if (value != _Name)
                {
                    _Name = value;
                    OnPropertyChanged();
                }
            }
        }
    
        private string _Company;
    
        public string Company
        {
            get { return _Company; }
            set
            {
                if (value != _Company)
                {
                    _Company = value;
                    OnPropertyChanged();
                }
            }
        }
    
        private int _Age;
    
        public int Age
        {
            get { return _Age; }
            set
            {
                if (value != _Age)
                {
                    _Age = value;
                    OnPropertyChanged();
                }
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
 
