    public abstract class Message
    {
        public string Content { get; set; }
        public override string ToString()
        {
            return Content;
        }
    }
    public class ServerMessage : Message
    {
    }
    public class ClientMessage : Message
    {
    }
