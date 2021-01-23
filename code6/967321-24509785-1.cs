    public string HirerName
        {
            get { return _HirerName; }
            set
            {
                if (String.IsNullOrEmpty(value)
                     throw new ArgumentException("Null or empty");
                
                if (value.Length < 3)
                     throw new ArgumentException("Too short");
    
                if (!string.Equals(_HirerName, value, StringComparison.Ordinal))
                {
                    _HirerName = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("HirerName"));
                }
            }
        }
