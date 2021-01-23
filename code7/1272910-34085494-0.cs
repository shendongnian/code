    public class EmailViewModel
    {
    }
    public class AccountClosedEmailViewModel:EmailViewModel    {
        public string Fullname { get; set; }
        public string ApplicationName { get; set; }
        public string Username { get; set; }
        public string RenewRegistrationUrl { get; set; }
    }
    public class AccountReopenedEmailViewModel:EmailViewModel{
        public string Fullname { get; set; }
        public string ApplicationName { get; set; }
        public string Username { get; set; }
        public string RenewRegistrationUrl { get; set; }
        public string CancelVerificationUrl { get; set; }
    }
    public class ContactFormEmailViewModel:EmailViewModel    {
        public string Fullname { get; set; }
        public string ApplicationName { get; set; }
    }
