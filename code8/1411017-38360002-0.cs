    public class Consumer
    {
        private readonly IUserService _userService;
        public Consumer(IUserService  userService)
        {
           _userService = userService;
        }
    
        public async Task ConsumeAsync()
        {
            // Correct
            var user = await _userService.GetUsers(1);
        }
    
        public void Consume()
        {
            // Will hang
            var user = _userService.GetUsers(1).Result;
        }
    }
