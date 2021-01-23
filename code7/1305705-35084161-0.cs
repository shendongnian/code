    public sealed JsonErrorResult : JsonResult
    {
        public JsonErrorResult(StatusCodes statusCode, object value)
            : base(value)
        {
            _statusCode = statusCode;
        }
    
        private readonly JsonErrorResult StatusCodes _statusCode;
    }
