    public interface IUserNameProvider 
    {
        String UserName { get; }
    }
    public class QueryStringUserNameProvider 
    {
        public QueryStringUserNameProvider(HttpRequestBase request)
        {
            this._request = request; 
        }
        private readonly HttpRequestBase _request; 
        public String UserName 
        {
            get 
            {
                return this._request.QueryString["UserName"];
            }
        }
    }
