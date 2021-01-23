    public class ManageController : BaseController
    {    
        private readonly IAccountContext _db;
        
        public ManageController()
        {
              // Here the base constructor has already been executed, so ConnectionName has the right value
             _db = new MainContext(ConnectionName);
        }
       // other actions
     }
