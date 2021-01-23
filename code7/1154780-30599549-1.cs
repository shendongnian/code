    private async Task<BrokeredMessage> ReceiveMessageAsync(MessageSession session)
        {
            BrokeredMessage message = null;
            // We can specify dead line for processing, but since our worker will return error message if a problem arise,
            // I prefer to wait endlessly
            // var timesToRetry = 0;
            // if Receive operation throws an exception, then message will be null
            while (message == null /* && timesToRetry < 5*/)
            {
                try
                {
                    var task = session.ReceiveAsync().ConfigureAwait(false);
                    await task;
                    message = task.GetAwaiter().GetResult();
                    //timesToRetry++;
                }
                catch (Exception e)
                {
                    // session was idle for a long time and azure closed it -> renew it
                    session = _responseQueueClient.AcceptMessageSession(session.SessionId);
                }
            }
            return message;
        } 
