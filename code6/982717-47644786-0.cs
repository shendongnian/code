    [ThriftStruct]
    public class LogEntry
    {
        [ThriftConstructor]
        public LogEntry([ThriftField(1)]String category, [ThriftField(2)]String message)
        {
            this.Category = category;
            this.Message = message;
        }
        [ThriftField(1)]
        public String Category { get; }
        [ThriftField(2)]
        public String Message { get; }
    }
    ThriftSerializer s = new ThriftSerializer(ThriftSerializer.SerializeProtocol.Binary);
    byte[] s = s.Serialize<LogEntry>();
    s.Deserialize<LogEntry>(s);
