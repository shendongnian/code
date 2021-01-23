    [ComVisible(true)]
    public class StringWrapper
    {
        private string wrappedString;
    
        public StringWrapper(string value)
        {
            wrappedString = value;
        }
    
        public override string ToString()
        {
            return wrappedString;
        }
    }
    
    CallVbsFunction(new StringWrapper("a"));
