    [DataContract]
    public class ApiResult<T>
    {
        [DataMember]
        public bool Success { get; internal set; }
    
        [DataMember]
        public T Result { get; internal set; }
    }
