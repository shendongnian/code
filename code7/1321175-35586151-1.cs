    public class CustomException : Exception 
    {
        public override string Message
        {
            get
            {
                return "Something bad happened";
            }
        }
    }
