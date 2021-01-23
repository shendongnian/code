    public interface ICommuniucationService
    {
        void SendEmail(....);
    }
    public class CommunicationService : ICommuniucationService
    {
        public void SendEmail(...)
        {
            //real implementation of sending email
        }
    }
    public class FakeCommunicationService : ICommuniucationService
    {
        public void SendEmail(...)
        { 
           //do nothing.
           return;
        }
    }
