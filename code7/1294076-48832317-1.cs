     public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationUserStore(Contexto.DataBaseContexto context) : base(context)
        {
           
        }
        
    }
