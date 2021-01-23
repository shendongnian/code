    public class UploadStatus
    {
        public string Status { get; private set; }
        public int Progress { get; private set; }
        public UploadStatus(string status)
        {
            Status = status;
        }
        public UploadStatus(int progress)
        {
            Progress = progress;
            Status = "in progress";
        }
    }
