    // Interface for DI reasons. :)
    interface IItineraryContainer { string Itinerary { get; } }
    class MyObj : IItineraryContainer
    {
        public string Itinerary { get; set; }
        public async void DoSomethingAsync()
        {
            ItineraryOperations.DoSomethingElseWith(this);
        }
    }
    class ItineraryOperations
    {
        public static void DoSomethingElseWith(IItineraryContainer container)
        {
            string valueToWorkWith = container.Itinerary;
        }
    }
