    class Alias : IDataErrorInfo
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Key) || columnName == nameof(Value))
                {
                    string aliasPattern = @"^[a-zA-Z]+[a-zA-Z0-9]*$";
                    string pathPattern = @"^[a-zA-Z0-9\\/@:_\-;]+$";
                    string key = Key ?? String.Empty;
                    string path = Value ?? String.Empty;
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
        public string Error
        {
            get
            {
                return string.Empty;
            }
        }
    }
