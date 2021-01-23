    public interface IHttpContextProvider
    {
        HttpContext CurrentContext { get; }
    }
    
    public class HttpContextProvider : IHttpContextProvider
    {
        public HttpContext CurrentContext => HttpContext.Current;
    }
    
    public interface IMyContextWrapper
    {
        string CurrentRoute { get; }
    }
    
    public class MyContextWrapper : IMyContextWrapper
    {
        private readonly IHttpContextProvider httpContextProvider;
    
        public MyContextWrapper(IHttpContextProvider httpContextProvider)
        {
            this.httpContextProvider = httpContextProvider;
        }
    
        public string CurrentRoute 
        {
            get
            {
                var context = this.httpContextProvider.CurrentContext;
                return informationFromContext;
            } 
        }
    }
