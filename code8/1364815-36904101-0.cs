    class NonLetterException : Exception
    {
        private static string msg = "Error input string is not of the alpahbet:";
        public NonLetterException(string input) : base(msg + input)
        {
    
        }
    }
