    public class MockClass : ApplicationUserManager
    {
        public MockClass(IUserStore<ApplicationUser> store, IIdentityMessageService emailService) : base(store, emailService)
        {
        }
        protected override void CalledAfterContruction()
        {
           
        }
    }
