    async void StartBot()
    {
      while(true)
      {
        string message = await irc.readMessageAsync();
        if (message.Contains("!test"))
        {
            irc.sentChatMessage("answer");
        }
      }
    }
    public async Task<string> readMessageAsync()
    {
       string message = await inputStream.ReadLineAsync();
       return message;
    }
