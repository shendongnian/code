    // Create our public properties
        protected DatabaseContext DbContext { get; private set; }
        protected UserService UserService { get { return Request.GetOwinContext().GetUserManager<UserService>(); } }
        protected RoleService RoleService { get { return Request.GetOwinContext().GetUserManager<RoleService>(); } }
        protected ModelFactory ModelFactory { get { return new ModelFactory(this.Request, this.UserService); } }
    
        public BaseController()
        {
            this.DbContext = new DatabaseContext();
        }
