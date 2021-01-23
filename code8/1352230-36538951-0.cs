    public async Task<IEnumerable<Tuple<Message, ulong>>> HandleMessage(Message message)
    {
        IEnumerable<Tuple<Message, ulong>> responses;
        try
        {
            if (!_communicateTypesToHandleSync.Contains(message.GetType()))
            {
                 responses = await Task.Run(() => _requestHandler.HandleRequest(message));
            }
            else
            {
                responses = _requestHandler.HandleRequest(message);
            }
            foreach (var response in responses)
            {
                CSMessageHandler.AddMessageToSend(response.Item1, response.Item2);
            }
    
            return responses;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error while handling message");
        }
    }
