    [ServiceContract]
    public interface IMyContract
    {
        [OperationContract]
        MyResult DoSomething();
    }
    
    [DataContract]
    public class MyResult
    {
        [DataMember]
        public bool IsSuccess { get; set; }
        [DataMember]
        public string ErrorDetails { get; set; }
    }
    public class MyService : IMyContract
    {
        public MyResult DoSomething()
        {
            try
            {
                return new MyResult { IsSuccess = true };
            }
            catch
            {
                return new MyResult { IsSuccess = false, ErrorDetails = "Bad things" };
            }
        }
    }
