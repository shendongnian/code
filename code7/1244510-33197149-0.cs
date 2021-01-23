    public interface IService
    {
        string GetSomething();
    }
    public class Service : IService
    {
        public string GetSomething()
        {
            return "Something nice";
        }
    }
    public class MyHandler : IHttpHandler
    {
        private readonly IService m_Service;
        public MyHandler(IService service)
        {
            m_Service = service;
        }
        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            response.Write("<html>");
            response.Write("<body>");
            response.Write(string.Format("From handler 1: <h2>{0}</h2>", m_Service.GetSomething()));
            response.Write("</body>");
            response.Write("</html>");
        }
        public bool IsReusable { get; private set; }
    }
