    public interface IReadWriteMedia : IReadOnlyMedia, IWritableMedia
    {
    }
    public class RewritableCompactDisk : IReadWriteMedia
    {
        public object Content { get; set; }
        public double recordingLength { get; set; }
    }
