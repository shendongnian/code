    public class JsonDataParser : IDataParser
    {
        public string ParseData(string input)
        {
            //Convert the input to JSON.
        }
    }
    public class DataHandler
    {
        private IDataParser _parser;
        public DataHandler(IDataParser parser)
        {
            _parser = parser;
        }
        public void ReceiveData(string data)
        {
            //Convert the data to the desired format.
            string result = _parser.ParseData(data);
        }
    }
