    public class Person : IDataErrorInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
    
        public string Error
        {
            get
            {
                return String.Concat(this[FirstName], " ", this[LastName], " ",
                                     this[City]);
            }
        }
    
        public string this[string columnName]
        {
            get
            {
                string errorMessage = null;
                switch (columnName)
                {
                    case "LastName":
                        if (String.IsNullOrWhiteSpace(LastName))
                        {
                            errorMessage = "LastName is required.";
                        }
                        break;
                }
                return errorMessage;
            }
        }
    }
