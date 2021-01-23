    public class EventChecker : ServiceBase
    {
        private static IUnityContainer container;
        public EventChecker(IUnityContainer container) {
            this.container = container;
        }
        public void SomeOperationThatGetsTriggeredByATimer() {
            using (this.container.StartSomeScope()) {
                var service = this.container.Resolve<IEventCheckerService>();
                service.Process();
            }
        }
    }
