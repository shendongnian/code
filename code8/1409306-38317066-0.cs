    public class ErrorStream {}
    public class ErrorStreamService : Service
    {
        [AddHeader(ContentType = "application/pdf")]
        public Stream Any(ErrorStream request)
        {
            throw new NotImplementedException("Exception in Stream Response");
        }
    }
