    public class EventController
    {
        public static readonly EventController Instance = new EventController();
        private EventController()
        {
            // Make constuctor private, so the class cannot be instantiated elsewhere.
        }
        // Implement functionality here...
    }
