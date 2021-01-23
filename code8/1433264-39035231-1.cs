        public string key;
        public string Key {
            get { return key; }
            set
            {
                if (key != value && this["KeyDisplay"] == string.Empty)
                {
                    key = value;
                    NotifyPropertyChanged("Key");
                }
            }
        }
        public string _value;
        public string Value
        {
            get { return _value; }
            set
            {
                if (_value != value && this["ValueDisplay"] == string.Empty)
                {
                    _value = value;
                    NotifyPropertyChanged("Value");
                }
            }
        }
        public string keyDisplay;
        public string KeyDisplay
        {
            get { return keyDisplay; }
            set
            {
                if (keyDisplay != value)
                {
                    keyDisplay = value;
                    Key = value;
                    NotifyPropertyChanged("KeyDisplay");
                }
            }
        }
        public string valueDisplay;
        public string ValueDisplay
        {
            get { return valueDisplay; }
            set
            {
                if (valueDisplay != value)
                {
                    valueDisplay = value;
                    Value = value;
                    NotifyPropertyChanged("ValueDisplay");
                }
            }
        }
        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(KeyDisplay) || columnName == nameof(ValueDisplay))
                {
                    string aliasPattern = @"^[a-zA-Z]+[a-zA-Z0-9]*$";
                    string pathPattern = @"^[a-zA-Z0-9\\/@:_\-;]+$";
                    string key = KeyDisplay ?? String.Empty;
                    string path = ValueDisplay ?? String.Empty;
                    bool isValidAlias = Regex.IsMatch(key, aliasPattern);
                    bool isValidPath = Regex.IsMatch(path, pathPattern);
                    if (isValidAlias && isValidPath)
                        return string.Empty;
                    else
                        return "Invalid alias / path";
                }
                return string.Empty;
            }
        }
