    async static Task<int> HandleMessage(BrokeredMessage message)
    {
      VideoMessage videoMessage = message.GetBody<VideoMessage>();
    
      message.CompleteAsync(); // This line...
    
      Console.WriteLine(String.Format("Message id: {0}", message.MessageId));
      // Processes Message
    }
