    public enum OperationStatus { Success, Failure, Pending }
    public class OperationResult<T>
    {
        public T Data { get; private set; }
        private OperationStatus opStatus;
        public string Status
        {
            get
            {
                return this.opStatus.ToString();
            }
            private set
            {
                var names = Enum.GetNames(typeof(OperationStatus));
                if (names.Contains(value))
                {
                    this.opStatus = (OperationStatus)Enum.Parse(typeof(OperationStatus), value);
                }
                else
                {
                    throw new Exception("Illegal Status Type");
                }
            }
        }
        public string Message { get; private set; }
        public bool IsSuccess
        {
            get
            {
                return this.Status == OperationStatus.Success.ToString();
            }
        }
        public OperationResult(OperationStatus status, string message, T data)
        {
            this.Data = data;
            this.Status = status.ToString();
            this.Message = message;
        }
        public static implicit operator bool(OperationResult<T> result)
        {
            return result.IsSuccess;
        }
    }
 
