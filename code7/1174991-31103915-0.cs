    public class SubscriptionService : ReceiveActor
    {
        private readonly ICanTell service1;
        private readonly ICanTell service2;
        public SubscriptionService(ICanTell service1, ICanTell service2)
        {
            this.service1 = service1;
            this.service2 = service2;
            this.Receive<RequestMessage>(message => this.ProcessRequestMessage(message));
        }
