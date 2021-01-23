    Public class AccountController: Controller
    {
        private readonly IOptions<List<Defined>> _customClients;
        public AccountController(IOptions<List<Defined>> customClients)
        {
            _customClient = customClients;
        }
      ...
    }
