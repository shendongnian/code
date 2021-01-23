    public class ThirdPartyServiceException : System.Exception
    {
        public ThirdPartyServiceException(string code, string message, string description, Exception innerException)
        :base(string.format("Error: {0} - {1} | {2}", code, message, description), innerException) 
        {        
        }
    }
