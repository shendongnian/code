    public interface IWritableMedia
    {
        object Content { set; }
        double recordingLength { set; }
    }
    
    public interface IReadOnlyMedia
    {
        object Content { get; }
        double recordingLength { get; }
    }
