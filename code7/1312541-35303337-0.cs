        Private IUserService userService;
        Private omegaentities dbcontext;
        Public UnitOfWork ()
        {
        dbcontext = new Omegaentities ();
        }
        Public IUserService UserService {
        get {
                 If (userService == null)
                 { userService = new UserService(dbcontext);}
    
        Return userService;
        }
        
    }
