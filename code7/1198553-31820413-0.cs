    enum Messages
    {
        Clear
    }
    
    class Mediator
    {
         public static Mediator Instance = new Mediator();
         public void Register(Message message, Action callback);
         public void BroadcastMessage(Message message);
    }
