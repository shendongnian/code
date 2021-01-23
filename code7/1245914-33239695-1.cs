    public class BadInputException : Exception 
    {
        public BadInputException()
        {
            this.Data.Add("Message", "You screwed up.")
        }
    }
