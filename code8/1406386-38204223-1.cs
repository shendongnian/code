    [Serializable]
    public class MyErrorInfo : ErrorInfo
    {
        public string MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
    }
    
    public class MyExceptionToErrorInfoConverter : IExceptionToErrorInfoConverter
    {
        public IExceptionToErrorInfoConverter Next { set { } }        
    
        public ErrorInfo Convert(Exception exception)
        {
            return new MyErrorInfo{ MyProperty1 = "test", MyProperty2  = 1};
        }
    }
