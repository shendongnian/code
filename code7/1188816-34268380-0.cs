    public class UserTrackingHub : Hub
    {
        private readonly Func<string, UserContext> _contextFactory;
        public UserTrackingHub(Func<string, UserContext> contextFactory) { ... }
        public override async Task OnConnected() { ... }
       
        public override async Task OnDisconnected(bool stopCalled)
        {
            var tenant = Context.Request.Cookies["app.tenant"].Value;
            using (var context = _contextFactory.Invoke(tenant))
            {
                var connection = await context.Connections.FindAsync(Context.ConnectionId);
                if (connection != null)
                {
                    context.Connections.Remove(connection);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
