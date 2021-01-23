    public interface IBroadcastMessage{
        public Status Status {get; set;}
        public DateTime DateStarted {get; set;}
    }
    public class Broadcast : IBroadcastMessage, ISearchQueryDto { /* ... */ }
    public class BroadcastMessage : IBroadcastMessage { /* ... */ }
    
