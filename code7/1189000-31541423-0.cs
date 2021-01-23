    public interface IProcessMail
    {
         bool CanProcess(MailType type);
         MailResult GetMailResult(Mail mail);
    }
