    [OperationContract]
    ResponseWithErrors SomeMethod(SomeRequest rq);
    
    public class ResponseWithErrors : IResponseWithErrors
    {
        public Error[] Errors { get; set; }
        public bool Success { get; set; }
    }
