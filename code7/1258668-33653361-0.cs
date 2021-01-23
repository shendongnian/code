    public class AccountController : Controller
    {
       private IRepository<Account> _accountRepository;
       public AccountController(IRepository<Account> accountRepository)
       {
          this._accountRepository = accountRepository;
       }
    }
