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
