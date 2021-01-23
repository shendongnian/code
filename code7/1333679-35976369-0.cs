     private IUserService UserService { get; set; }
        public UserController(IUserService userService)
        {
            UserService = userService;
        }
