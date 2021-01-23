    public Message Add(GatewayMessageTypes type, string strMessage, CultureInfo language)
    {
      lock(_messages)
      {
        var message = new Message(type, strMessage, language);
        int intCount = _messages.Count + 1;
        if (_messages.ContainsKey(intCount))
        {
            _messages.Remove(intCount);
        }
        _messages.Add(intCount, message);
        return message;
      }
    }
