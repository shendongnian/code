        public static ErrorMessageTest HandleErrorTest(string EventId, string TransactionId, 
                                       DateTime Timestamp, string Component,
                                       string UserId)
            {
      return new ErrorMessageTest
        {
         EventId = eventId,
         TransactionId = transactionId,
         Timestamp = timeStamp,
         Component = component,
         UserId = userId
        };
           }
