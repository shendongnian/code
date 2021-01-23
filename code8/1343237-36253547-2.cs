    [AllowAnonymous]
    [RoutePrefix("api/home")]
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("ok")]
        public MyResponse<MyUser> OK()
        {
            MyUser m = new MyUser();
            var r = MyResponse<MyUser>.Success(m);
            return r;
        }
        [Route("nok")]
        [HttpGet]
        public MyResponse<MyUser> NOK()
        {
            var r = MyResponse<MyUser>.Error("something went terribly wrong");
            return r;
        }
    }
    public class MyResponse<T>
    {
        public T Data { get; set; }
        public Status ResponseStatus { get; set; }
        public string Message { get; set; }
        private MyResponse() { }
        public static MyResponse<T> Success(T data)
        {
            return new MyResponse<T> { Data = data, ResponseStatus = Status.Success };
        }
        public static MyResponse<T> Error(string message)
        {
            return new MyResponse<T> { ResponseStatus = Status.Error, Message = message };
        }
    }
    public class MyUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public enum Status
    {
        Unknown = 0,
        Success = 1,
        Error
    }
