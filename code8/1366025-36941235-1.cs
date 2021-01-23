    public class DriverService : IDriverService, IEventSubscriber<PlanCreated>
    {
        public void Handle(PlanCreated evt)
        {
            //handle it here.
        }
    }
