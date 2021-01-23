        // if a ReplyToSessionId has been specified, it means that the sender is
        // actively waiting for a response
        if (!String.IsNullOrEmpty(receivedMessage.ReplyToSessionId))
        {
            // now respond on sync response queue
            var responseMessage = new BrokeredMessage(response)
            {
                SessionId = receivedMessage.ReplyToSessionId
            };
            // consider allowing client to specify a ReplyTo response queue (not needed for now)
            await ServiceBusConnector.Instance.SyncResponseClient.SendAsync(responseMessage);
        }
