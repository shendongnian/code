    public class MyHub: Hub
    {
        public override Task OnConnected()
        {
            // ConnectionId is what we want - establish groups here by whatever criteria
            Groups.Add(Context.ConnectionId, Context.User.Identity.Name) // unique group per user
            return base.OnConnected();
        }
    }
