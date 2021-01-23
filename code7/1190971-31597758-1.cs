    public class RoyalMailMessageFormatter: IClientMessageFormatter {
      private readonly IClientMessageFormatter formatter;
      public RoyalMailMessageFormatter(IClientMessageFormatter formatter) {
        this.formatter = formatter;
      }
      public object DeserializeReply(Message message, object[] parameters) {
        return this.formatter.DeserializeReply(message, parameters);
      }
      public Message SerializeRequest(MessageVersion messageVersion, object[] parameters) {
        var message = this.formatter.SerializeRequest(messageVersion, parameters);
        return new RoyalMailMessage(message);
      }
    }
