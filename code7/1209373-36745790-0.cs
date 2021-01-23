    [HubName("receipts")]
    public class ReceiptsHub : Hub
    {
        public IUnitOfWork<string> UnitOfWork { get; set; }
        public ReceiptsHub(IUnitOfWork<string> unitOfWork) : base()
        {
            UnitOfWork = unitOfWork;
        }
     
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }
    }
