    public interface IEmailService
    {
        void SendEmail(string subject, string body, params string[] to);
    }
    public class EmailService : IEmailService
    {
        public void SendEmail(string subject, string body, params string[] to)
        {
             //gubbins
        }
     }
