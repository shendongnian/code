    public class ErrorMessage
    {
        public string EventId;
        public string TransactionId;
        public DateTime Timestamp;
        public string Component;
        public string UserId;
        public string Message;
        public string Exception;
    }
    public class ErrorHandlerTest
    {
        public static ErrorMessage HandleErrorTest(string EventId, string TransactionId,
                                           DateTime Timestamp, string Component,
                                           string UserId)
        {
            return new ErrorMessage()
            {
                Component = Component,
                EventId = EventId,
                Timestamp = Timestamp,
                TransactionId  = TransactionId,
                UserId = UserId
            };
        }
    }
