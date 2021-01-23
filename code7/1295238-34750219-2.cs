        private Dictionary<string, string> _listOfString = new Dictionary<string, string>
        { 
            {"0", "TextToDisplay" }
        };
        public Dictionary<string, string> ListOfString
        {
            get
            {
                return _listOfString;
            }
            set
            {
                if (_listOfString.Equals(value))
                {
                    return;
                }
                _listOfString = value;
            }
        }
