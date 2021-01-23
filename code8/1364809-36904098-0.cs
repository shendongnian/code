    class NonLetterException : Exception
    {
        private static string msg = "Error input string ({0}) is not of the alpahbet. ";
        public NonLetterException(char c) : base(string.Format(msg, new String(c,1)))
        {
    
        }
    }
