    public abstract class ApiResult
    {
        /// <summary>
        /// is success
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// I think you want use a error code here
        /// </summary>
        public string Error{get;set;}
        /// <summary>
        /// message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// error 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ApiResult Error(string message)
        {
            return new ErrorApiResult(message);
        }
        /// <summary>
        /// Success
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ApiResult<T> Success<T>(T data)
        {
            return new ApiResult<T>()
            {
                Success = true,
                Message = null,
                Data = data
            };
        }
    }
    public class ErrorApiResult:ApiResult {
        public ErrorApiResult(string errorCode,string message)
        {
            Message = message;
            Success = false;
            Error = errorCode;
        }
    }
    public class ApiResult<T>: ApiResult
    {
       
        /// <summary>
        /// the success return data
        /// </summary>
        public T Data { get; set; }
        public static ApiResult<T> Error(string message)
        {
            return new ApiResult<T>() {Message = message, Success = true};
        }
        public static ApiResult<T> Error(bool isSuccess,string message)
        {
            return new ApiResult<T>() {Message = message, Success =isSuccess};
        }
    }
