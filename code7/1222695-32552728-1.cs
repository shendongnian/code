    internal interface ITrackerViewModelFactory
    {
        TrackerViewModel Create(IWindow window);
    }
    internal class TrackerViewModelFactory : ITrackerViewModelFactory
    {
        private readonly ISystemEvents systemEvents;
        public TrackerViewModelFactory(ISystemEvents systemEvents)
        {
            if (systemEvents == null)
            {
                throw new ArgumentNullException("systemEvents");
            }
            this.systemEvents = systemEvents;
        }
        public TrackerViewModel Create(IWindow window)
        {
            if (window == null)
            {
                throw new ArgumentNullException("window");
            }
            return new TrackerViewModel(this.systemEvents, window);
        }
    }
