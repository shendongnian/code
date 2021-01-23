    public class RoomRequestResult
    {
        public bool Success { get; set; }
        public Room ResultValue { get; set }
        public RoomConflict FailureReason { get; set; }
    }
