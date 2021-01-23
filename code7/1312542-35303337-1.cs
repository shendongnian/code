        private IUserService userService;
        private omegaentities dbcontext;
        public UnitOfWork ()
        {
        dbcontext = new Omegaentities ();
        }
        public IUserService UserService {
        get {
                 If (userService == null)
                 { userService = new UserService(dbcontext);}
    
        Return userService;
        }
        
    }
