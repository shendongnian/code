    public abstract class MailClient<TMessage> where TMessage: IMessage
    {
        public IAuthentication MailAuthentication { get; set; }
        internal MailClient(IAuthentication mailAuthenticaton)
        {
            this.MailAuthentication = mailAuthenticaton;
        }
        public abstract State SendMessage(TMessage message);
        public abstract List<TMessage> GetEmails();
    }
