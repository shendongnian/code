     public class ABC: IDataErrorInfo 
     {
        private string _PersonName;
        public string PersonName
        {
            get { return _PersonName; }
            set
            {
                _PersonName = value;
                OnPropertyChanged("PersonName");
            }
        }
        public string Error
        {
            get { return string.Empty; }
        }
        public string this[string columnName]
        {
            get
            {
                if ("PersonName" == columnName)
                {
                    if (String.IsNullOrEmpty(PersonName))
                    {
                        return "Your Error Message";
                    }
                }
	      }
	 }
