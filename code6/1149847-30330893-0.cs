    // States
    public enum MessageType
    {
        Done,
        Work1,
        Work2,
        Work3,
        Work4
    }
    
    // Data
    public class WorkerStateMessage
    {
        public static readonly WorkerStateMessage Done =
            new WorkerStateMessage { Type = MessageType.Done };
        public MessageType Type { get; set; }
        public string Progress { get; set; }
        public int Data { get; set; }
    }
