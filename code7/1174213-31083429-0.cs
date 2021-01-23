    public class FakeNotificationMailer : MailerBase, INotificationMailer
        {
        MvcMailMessage preBuiltMessage;
        public NotificationMailer(MvcMailMessage result)
            {
            preBuiltMessage = result;
            }
    
        public virtual MvcMailMessage Notify(string message)
            {
            return preBuiltMessage;
            }
        }
