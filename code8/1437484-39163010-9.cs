        public class Response<T>
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
            public IEnumerable<T> ResponseData { get; set; }
    
            public Response(bool status, string message, IEnumerable<T> data)
            {
                IsSuccess = status;
                Message = message;
                ResponseData = data;
            }
        }
