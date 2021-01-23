    public class AccountController : BaseController
    {
        public AccountController()
        {
        }
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            contactManager = new ContactManager(UnitOfWork);
        }
        public ActionResult CreateContact(string firstName, string lastName, string email)
        {
			ContactModel contact = contactManager.Create(firstName, lastName, email);
			
			return JsonNet(new { contact = contact });
        }
		#region Private members
		private IContactManager contactManager;
		#endregion
    }
