    public abstract class Response
    {
        public abstract string name { get; }
    }
    public class Response<TResponse> : Response where TResponse : Response<TResponse>
    {
        private static string _name = typeof(TResponse).Name;
        public override string name => _name;
    }
    // Base ResponseEnum class to be used by more specific enum sets
    public abstract class ResponseEnum<TResponseEnum> : StringEnum<TResponseEnum>
        where TResponseEnum : ResponseEnum<TResponseEnum>
    {
        protected ResponseEnum(string responseName) : base(responseName) {}
        public abstract ActionResult GenerateView(Response response);
    }
