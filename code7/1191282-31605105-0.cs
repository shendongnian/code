    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string ResultCode { get; set; }
        public string ResultMessage { get; set; }
        public string Exception { get; set; }
    }
