    public class RewritableCompactDisk : IReadOnlyMedia, IWritableMedia
    {
        public object Content { get; set; }
        public double recordingLength { get; set; }
    }
