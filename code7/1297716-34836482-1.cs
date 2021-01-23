    public class Contract : INotifyPropertyChanged
    {
        private int _id;
        private string _companyName;
        private string _headName;
        private string _countryCode;
        private string _operatorCode;
        private string _date;
        private string _time;
        private string _telephones;
        private string _comment;
        private TextCell _smth;
    
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
    
        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                _companyName = value;
                OnPropertyChanged();
            }
        }
    
        public string HeadName
        {
            get { return _headName; }
            set
            {
                _headName = value;
                OnPropertyChanged();
            }
        }
    
        public string CountryCode
        {
            get { return _countryCode; }
            set
            {
                _countryCode = value;
                OnPropertyChanged();
            }
        }
    
        public string OperatorCode
        {
            get { return _operatorCode; }
            set
            {
                _operatorCode = value;
                OnPropertyChanged();
            }
        }
    
        public String Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }
    
        public String Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }
    
        public String Telephones
        {
            get { return _telephones; }
            set
            {
                _telephones = value;
                OnPropertyChanged();
            }
        }
    
        public String Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                OnPropertyChanged();
            }
        }
    
        public TextCell smth
        {
            get { return _smth; }
            set
            {
                _smth = value;
                OnPropertyChanged();
            }
        }
    
        /*public Dictionary<string, int> PriceFields { get; private set; }
        public Dictionary<string, string> RateFields { get; private set; }
        public Dictionary<string, string> TypeFields { get; private set; }
        public Dictionary<string, string> TicketFields { get; private set; }*/
    
        public Contract()
        {
            smth = new TextCell();
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
