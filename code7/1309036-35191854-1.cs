        private string _message;
        private TimeSpan _automatedPeriod;
        public HelloWorldController(string Message, TimeSpan automatedPeriod)
        {
            _message = Message;
            _automatedPeriod = automatedPeriod;
        }
