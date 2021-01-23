    public abstract class EmailService
    {
        public static readonly Lazy<EmailService> Instance = new Lazy<EmailService>(() => DependencyService.Get<EmailService>());
        public abstract bool CanSend { get; }
        public abstract void ShowDraft(string subject, string body, bool html, string to, byte[] screenshot = null);
        public abstract void ShowDraft(string subject, string body, bool html, string[] to, string[] cc, string[] bcc, byte[] screenshot = null);
    }
