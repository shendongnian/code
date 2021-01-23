        private string _uName;
        private object _countryData;
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                OnPropertyChanged();
            }
        }
        public string UName
        {
            get { return _uName; }
            set
            {
                _uName = value;
                OnPropertyChanged();
            }
        }
        public object CountryData
        {
            get { return _countryData; }
            set
            {
                _countryData = value;
                OnPropertyChanged();
            }
        }
    }
    public class ActivityStatus:BaseObservableObject
    {
        private bool _boolStatus;
        private string _verbalStatus;
        public bool BoolStatus
        {
            get { return _boolStatus; }
            set
            {
                _boolStatus = value;
                OnPropertyChanged();
            }
        }
        public string VerbalStatus
        {
            get { return _verbalStatus; }
            set
            {
                _verbalStatus = value;
                OnPropertyChanged();
            }
        }
    }
    public class Country : BaseObservableObject
    {
        private string _countryName;
        private string _countryPop;
        public string CountryName
        {
            get { return _countryName; }
            set
            {
                _countryName = value;
                OnPropertyChanged();
            }
        }
        public string CountryPop
        {
            get { return _countryPop; }
            set
            {
                _countryPop = value;
                OnPropertyChanged();
            }
        }
        public Country() { }
        public Country(string n, string d)
        {
            this.CountryName = n;
            this.CountryPop = d;
        }
    }
