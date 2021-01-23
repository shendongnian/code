	public class JpegHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }
        public void ProcessRequest(HttpContext context)
        {
            var url = context.Request.Url.PathAndQuery;
            var path = context.Server.MapPath(url);
            try
            {
                if (File.Exists(path) || TryRecreateFile(url)) // TryRecreateFile attempts to create the file and if it succeeds, it returns true
                {
                    context.Response.Clear();
                    context.Response.ContentType = "image/jpeg";
                    context.Response.TransmitFile(path);
                    //Response.End(); // TransmitFile already Ends the response
                    return;
                }
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                Logger.LogException(ex);
                return;
            }
            context.Response.StatusCode = 404;
        }
	}
