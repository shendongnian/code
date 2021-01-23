    class MyException : Exception
    {
        // some enhancements
        public string ExtraData;
        public MyException(string sMessage, string sExtraData)
            : base(sMessage)
        {
            ExtraData = sExtraData;
        }
    }
