    interface IMessage
    {
       int id;
    
       //...
    
       object chat {get;}
    }
    public class GroupMessage : IMessage
    {
       public int id;
       public GroupChat group;
       public object chat {get {return group;} }
    }
    public class UserMessage : IMessage
    {
       public int id;
       public User user;
       public object chat {get {return user;} }
    }
       
