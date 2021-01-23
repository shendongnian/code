        public string Error
        {
            get
            {
                return string.Empty;
            }
        }
        public string this[string columnName]
        {
            get
            {
                if (columnName == "MyInteger")
                {
                    if (MyInteger < 0)
                    {
                        return "Must be an integer greater than 0!";
                    }
                }
                return "";
            }
        }
