    public class ApiResult<T>
    {
        public bool Success { get; }
        public T Dto { get; }
        public ApiResult(bool success, T dto)
        {
            Success = success;
            Dto = dto;
        }
    }
