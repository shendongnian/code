    public interface Chat
    {
      // chat properties
    }
    
    public User : Chat
    {
    }
    
    public GroupChat: Chat
    {
    }
    
    public Processor
    {
      public void Receive(Message mesage)
      {
         var user = message.Chat as User;
         if(user != null)
         // Handle user specific
      }
      public Message Send()
      {
         if(single)
           return new Message() { Chat = new User() };
         else
           return new Message() { Chat = new ChatGroup() };
      }
    }
