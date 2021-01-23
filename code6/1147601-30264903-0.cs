    public class TraceLogEntity : MongoRepository.Entity
    {
        public string ClassName { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public TraceLogEntity InnerException { get; set; }
        public string MethodName { get; set; }
    }
