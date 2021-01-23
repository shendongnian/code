    public class JsRoutingHttpHandler : IHttpHandler
    {
        public JsRoutingHttpHandler()
        {
        }
        public bool IsReusable
        {
            get { return true; }
        }
        public void ProcessRequest(HttpContext context)
        {
            var phisicalPath = context.Server.MapPath(context.Request.AppRelativeCurrentExecutionFilePath);
            var file = File.ReadAllLines(phisicalPath);
            var routeCatchRegex = new Regex(@"\[Route:([a-zA-Z]+)\]");
            for (int index = 0; index < file.Length; index++)
            {
                var line = file[index];
                var matches = routeCatchRegex.Matches(line);
                foreach (Match match in matches)
                {
                    var routeName = match.Groups[1];
                    var url = "ERROR[NO ROUTE FOUND]";
                    if (Resolver.RouteUrl.ContainsKey(routeName.Value))
                    {
                        url = Resolver.RouteUrl[routeName.Value];
                    }
                    line = line.Replace(match.Value, url);
                }
                context.Response.Output.WriteLine(line);
            }
        }
    }
