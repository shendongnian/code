    public class MyHub : Hub
    {
        public IState State { get; set; }
        
        public MyHub()
        {
            State = (IState) Startup.__serviceProvider.GetRequiredService(typeof (IState));
        }
        public override Task OnConnected()
        {
            State.Clients = Clients;
            State.Groups = Groups;
            return base.OnConnected();
        }
    }
