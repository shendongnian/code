    [DataContract]
    [KnownType(typeof(RecordNotFoundException))]
    [KnownType(typeof(StoreProcNotFoundException))]
    public class ExceptionFault
    { 
        [DataMember]
        public UserExceptions Exception { get; set; }
    
        public ExceptionFault(UserExceptions ex)
        {
            this.Exception = ex;
        }
    }
