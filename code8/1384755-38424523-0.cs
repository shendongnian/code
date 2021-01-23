    public class SampleClass : IPathMapper 
    {
        public MapPath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
    }
