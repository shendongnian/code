    class Test
    {
        public string testValue, mType;
        public Test(string value, string messageType)
        {
            Initialise(value, messageType);
        }
        public Test (string value)
        {
            // Do some manipulation here and found out the value of messageType.
            Initialise(value, messageType);
        }
        protected void Initialise(string value, string messageType)
        {
            this.testValue = value;
            this.mType = messageType;
        }
    }
