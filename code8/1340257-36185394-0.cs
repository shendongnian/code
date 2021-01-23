    public class ActionClass
    {
        public static Tuple<TRes, TInfo> GetTestTuple<TReq, TRes, TInfo>(string resultMsg, string userName)
            where TReq : BaseRequest, new()
            where TRes : BaseResponse, new()
            where TInfo : CallInfo<TReq>
        {
            var response = new TRes { Message = resultMsg };
            var eventsInfo = (TInfo)Activator.CreateInstance(typeof(TInfo), new []{ new TReq() });
            eventsInfo.Data.UserName = userName;
 
            return new Tuple<TRes, TInfo>(response, eventsInfo);
        }
    }
 
    public class BaseCallInfo
    {
        public string CallItem { get; set; }
    }
 
    public class BaseRequest
    {
        public string UserName { get; set; }
    }
 
    public class BaseResponse
    {
        public string Message { get; set; }
    }
 
    public class Request : BaseRequest
    {
    }
 
    public class Response : BaseResponse
    {
 
    }
 
    public class RequestCallInfo : CallInfo<Request>
    {
        public string Item { get; set; }
 
        public RequestCallInfo(Request x) : base(x)
        {
 
        }
    }
 
    public class CallInfo<GenericType> : BaseCallInfo where GenericType : BaseRequest, new()
    {
        public GenericType Data { get; set; }
 
        public CallInfo(GenericType x)
        {
            Data = x;
        }
    }
 
 
}
