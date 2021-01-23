    partial class Customer : IDataErrorInfo
    {
        static bool isAccessedFirstTime;
        static Customer()
        {
            isAccessedFirstTime = true;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "FirstName")
                {
                    if (! isAccessedFirstTime && string.IsNullOrWhiteSpace(FirstName))                    
                        result = "Please enter A First Name";
                }
                if (columnName == "LastName")
                {
                    if (!isAccessedFirstTime && string.IsNullOrEmpty(LastName))
                        result = "Please enter a Last Name";
                }
                if (columnName == "Age")
                {
                    if (!isAccessedFirstTime && (Age <= 0 || Age >= 99))
                        result = "Please enter a valid age";
                }
                isAccessedFirstTime = false;
                return result;
            }
        }
        public string Error { get; private set; }
    }
