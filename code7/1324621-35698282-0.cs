    public class EventType
    {
        public string Type { get; set; }
    }
    public class AggregatedType
    {
        public string EventType { get; set; }
        public int Count { get; set; }
    }
    class Program
    {
        public delegate void ExampleEventHandler(EventType e);
        public static event ExampleEventHandler Event;
        static void Main(string[] args)
        {
            var subscription = Observable.FromEvent<ExampleEventHandler, EventType>(e => Event += e, e => Event -= e)
                .GroupByUntil(e => e.Type, e => e.Buffer(TimeSpan.FromSeconds(1)))
                .SelectMany(e => e
                    .Select(ev => new AggregatedType {  EventType = ev.Type })
                    .Aggregate(new AggregatedType(), (a, ev) => new AggregatedType { EventType = ev.EventType, Count = a.Count + 1 }))
                .Subscribe(OnAggregaredEvent, OnException, OnCompleted);
            Event(new EventType { Type = "A" });
            Event(new EventType { Type = "A" });
            Event(new EventType { Type = "B" });
            Event(new EventType { Type = "B" });
            SpinWait.SpinUntil(()=> false, TimeSpan.FromSeconds(2));
            Event(new EventType { Type = "A" });
            Event(new EventType { Type = "A" });
            Event(new EventType { Type = "B" });
            Event(new EventType { Type = "B" });
            Console.ReadLine();
        }
        static void OnAggregaredEvent(AggregatedType aggregated)
        {
            Console.WriteLine("Type: {0}, Count: {1}", aggregated.EventType, aggregated.Count);
        }
        static void OnException(Exception ex)
        {
        }
        static void OnCompleted()
        {
        }
    }
