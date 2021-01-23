    public class ViewRClientException : Exception
    {
        public ViewRClientException(ErrorType errorType, List<ClientError> errorEntity)
        {
            ErrorTypeDetail = errorType;
            ClientErrorEntity = errorEntity;
        }
    
        public ErrorType ErrorTypeDetail { get; private set; }
        public List<ClientError> ClientErrorEntity { get; private set; }
    }
