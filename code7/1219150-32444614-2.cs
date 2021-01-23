    public enum UploadState
    {
        Uploading,
        InProgress,
        Completed,
        Unknown
    }
    public class UploadStatus
    {
        public UploadState State { get; private set; }
        public int Progress { get; private set; }
        public UploadStatus(UploadState state)
        {
            State = state;
        }
        public UploadStatus(int progress)
        {
            Progress = progress;
            State = UploadState.InProgress;
        }
    }
