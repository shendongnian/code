    [Authorize]
    public class MessageHub : Hub
    {
    }
    
    public static class MessageHubHelper
    {
        private static readonly IHubContext _hubContext =
            GlobalHost.ConnectionManager.GetHubContext<MessageHub>();
        public static IHubContext Context
        {
            get { return _hubContext; }
        }
        public static void Send(User user, Message message)
        {
            _hubContext.Clients.User(GetUserId(user)).Send(message);
        }
        public static void DoSomethingElse(User user, Message message)
        {
            _hubContext.Clients.User(GetUserId(user)).DoSomethingElse(message);
        }
        private static string GetUserId(User user)
        {
            return user.IdentityUser.UserName;
        }
    }
