    public class HistoricalEvent 
    {
        public DateTime historicDate { get; set; }
        public decimal historicEvent { get; set; }
    }
    List<HistoricalEvent> historicalEvents = new List<HistoricalEvent>();
    historicalEvents.Add(new HistoricalEvent());
    // ... etc etc ...
