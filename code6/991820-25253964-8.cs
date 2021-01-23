    public interface IEventService
    {
        ObservableCollection<String> GetEvents();
        void AddEvent(String eventToAdd);
    }
    public  class EventService : IEventService
    {
        private readonly ObservableCollection<string> events;
        public EventService(ObservableCollection<string> events)
        {
            this.events = events;
        }
        public EventService()
        {
            events = new ObservableCollection<string>();
        }
        public ObservableCollection<string> Events
        {
            get { return events; }
            //set { events = value; }
        }
        public ObservableCollection<String> GetEvents()
        {
            return events;
        }
        public void AddEvent(String eventToAdd)
        {
            events.Add(eventToAdd);
        }
    }
