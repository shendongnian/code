    public class MessageA : IMessage
    {
        public int SpecificAField;
    }
    public class MessageB : IMessage {}
    public class MessageAListener : IMessageListener<MessageA>
    {
        public void ProcessMessage(MessageA message)
        {
            messageA.SpecificAField = 3;
        }
    }
