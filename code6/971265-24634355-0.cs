     [DataContract]
    public class OperationResult<T>
    {
        [DataMember]
        public List<Error> Errors { get; set; }
        [DataMember]
        public T ResultObject { get; set; }
        [DataMember]
        public bool Success { get; private set; }
        public OperationResult(List<Error> errors)
        {
            Errors = errors;
        }
        public OperationResult(T resultObject)
        {
            ResultObject = resultObject;
            Success = true;
        }
        public OperationResult()
        {
        }
    }
