    public class PolicyAddressChangeHandler : IDomainEventHandler<PolicyAddressChangedEvent>
        {
            private readonly ILoggingService _loggingService;
    
            public PolicyAddressChangeHandler(ILoggingService loggingService)
            {
                _loggingService = loggingService;
            }
    
            public void Handle(PolicyAddressChangedEvent domainEvent)
            {
                _loggingService.Info("New policy address recorded", new Dictionary<string, object> { { "new address", domainEvent.NewAddress } }, "FrameworkSample");
                //this could be event hub, queues, or signalR messages, updating a data warehouse, sending emails, or even updating other domain contexts
            }
        }
