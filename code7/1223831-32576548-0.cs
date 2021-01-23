    namespace MikesProject
    {
        public class ZipThingy: IHttpHandler, IReadOnlySessionState
        {
            public void ProcessRequest(HttpContext context)
            {
                var request = context.Request;
                var response = context.Response;
            }
        }
    }
