    public class TestInfo
    {
        private string _testNumber;
    
        public int Id { get; set; }
        public string TestNumber
        {
            get
            {
                if (string.IsNullOrEmpty(_testNumber))
                {
                    _testNumber = "0";
                }
                return _testNumber;
            }
            set { _testNumber = value; }
        }
    }
