    public class MyHub: Hub
    {
        public override Task OnConnected()
        {
            // ConnectionId is what we want - establish groups here
            Groups.Add(Context.ConnectionId, "FooGroup") // or whatever you wish to group by
        }
    }
