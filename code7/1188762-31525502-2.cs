    public class MyHub: Hub
    {
        public override Task OnConnected()
        {
            Groups.Add(Context.ConnectionId, Context.User.Identity.Name)
            return base.OnConnected();
        }
    }
