    public interface ISendMessage
    {
        void Send();
    }
    public class SmsSender : ISendMessage
    {
        public void Send()
        {
            // Code to send SMS
        }
    }
    public class EmailSender : ISendMessage
    {
        public void Send()
        {
            // Code to send Email
        }
    }
