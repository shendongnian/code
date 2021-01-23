    public class ServerPathProvider: IPathProvider {
        public MapPath(string path) {
            return HttpContext.Current.Server.MapPath(path);
        }
    }
