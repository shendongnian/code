    public class Person : IDataErrorInfo, INotifyPropertyChanged
    {
        private string _fname;
        private string _lname;
        public String Fname
        {
            get { return _fname; }
            set { _fname = value; OnPropertyChanged("Fname"); }
        }
        public String Lname
        {
            get { return _lname; }
            set { _lname = value; OnPropertyChanged("Lname"); }
        }
        public string Error
        {
            get { return ""; }
        }
        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "Fname")
                {
                    if (string.IsNullOrEmpty(Fname))
                    {
                        result = "First name is required.";
                        return result;
                    }
                    string st = @"!|@|#|\$|%|\?|\>|\<|\*";
                    if (Regex.IsMatch(Fname, st))
                    {
                        result = "Contains invalid characters.";
                        return result;
                    }
                }
                if (columnName == "Lname")
                {
                    if (string.IsNullOrEmpty(Lname))
                    {
                        result = "Cannot be empty.";
                        return result;
                    }
                }
                return null;
            }
        }
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(String param)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(param));
            }
        }
        #endregion
    }
