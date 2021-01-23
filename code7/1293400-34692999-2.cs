    public class MyInputData
            : IDataErrorInfo
        {
            public string SomeInput { get; set; }
    
            public string this[string columnName]
            {
                get
                {
                    string result = null;
                   
                    if (columnName == "SomeInput")
                    {
                        if (string.IsNullOrEmpty(SomeInput))
                            result = "Please enter a Input Data";
                    }
    
                    Error = result;
                    return result;
                }
            }
    
            public string Error { get; private set; }
        }
