    public class MessageArray
    {
        public Message[] Messages;
    }
    var messages = JsonConvert.DeserializeObject<MessageArray>(json, new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });
