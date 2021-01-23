    partial class Customer : IDataErrorInfo
        {
            static bool isFirstNameInitializing;
            static bool isLastNameInitializing;
            static bool isAgeInitializing;
    
            static Customer()
            {
                isFirstNameInitializing = true;
                isLastNameInitializing = true;
                isAgeInitializing = true;
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
                        if (!isFirstNameInitializing && string.IsNullOrWhiteSpace(FirstName)) 
                            result = "Please enter A First Name";
                        isFirstNameInitializing = false;
                    }
                    else if (columnName == "LastName")
                    {
                        if (!isLastNameInitializing && string.IsNullOrEmpty(LastName))
                            result = "Please enter a Last Name";
                        isLastNameInitializing = false;
                    }
                    else if (columnName == "Age")
                    {
                        if (!isAgeInitializing && (Age <= 0 || Age >= 99))
                            result = "Please enter a valid age";
                        isAgeInitializing = false;
                    }
                    
                    return result;
                }
            }
    
            public string Error { get; private set; }
