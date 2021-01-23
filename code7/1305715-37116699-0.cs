    public sealed class JsonErrorResult : JsonResult {
        private readonly HttpStatusCode _statusCode;
        public JsonErrorResult(HttpStatusCode sCode, object value) : base(value) {
            _statusCode = sCode;
        }
        public override Task ExecuteResultAsync(ActionContext context) {
            context.HttpContext.Response.StatusCode = (int)_statusCode;
            return base.ExecuteResultAsync(context);
        }
        public static JsonResult JsonError(HttpStatusCode statusCode,
                                                   string message, string error = "") {
            var result = new JsonResult(new {
                StatusCode = Convert.ToString((int)statusCode),
                Error = error,
                Message = message
            });
            result.StatusCode = (int)statusCode;
            return result;
        }
    }
    
