    public interface IEmailRepository
    {
        void Add(Email email);
    
        Email GetById(int emailId);
    }
    
    public class EmailRepository : IEmailRepository
    {
        private EmailDbContext _context;
    
        public EmailRepository(EmailDbContext context)
        {
            _context = context;
        }
    
        public void Add(Email email)
        {
            _context.Emails.Add(email.State);
        }
    
        public Email GetById(int emailId)
        {
            EmailState emailState = _context.Emails.Single(x => x.Id == emailId);
    
            return new Email(emailState);
        }
    }
