    public partial class ExampleContext : IExampleContext
    {
        private YourContext _context;
        private string _user;
        public ExampleContext(YourContext context, UserResolverService userService)
        {
            _context = context;
            _user = userService.GetUser();
        }
    }
