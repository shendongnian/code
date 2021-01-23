    [Serializable]
    public class ClassOne : ClassTwo
    {
        private string _parameterOne;
        private string _parameterTwo;
        private string _parameterThree;
    
        public Category() { }
        public Category (string parameterOne, string parameterTwo, string parameterThree)
        {
            _parameterOne = parameterOne;
            _parameterTwo = parameterTwo;
            _parameterThree = parameterThree;
        }
    }
