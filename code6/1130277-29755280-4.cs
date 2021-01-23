    public class CustomException : Exception
    {
        private string message;
        public override string Message
        {
            get { return string.Format("{0}: {1}", DateTime.Now, message); }
        }
        public CustomException(string message)
        {
            this.message = message;
        }
    }
