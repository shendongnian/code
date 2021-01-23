    public enum RequestStatus
    {
        Approved,
        Rejected,
        Cancelled,
        UnableToCarryOut
    }
    public class RequestResult
    {
        public RequestStatus Status { get; set; }
        public string Message { get; set; }
    }
