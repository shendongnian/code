    public class CacheRoutePatternProvider : IRoutePatternProvider
    {
        public string GetRoutePattern(HttpRequestMessage request)
        {
            string path = request.RequestUri.AbsolutePath;
            if (!path.EndsWith("/"))
                path += "/";
            return path;
        }
        public IEnumerable<string> GetLinkedRoutePatterns(HttpRequestMessage request)
        {
            string path = request.RequestUri.AbsolutePath;
            if(!path.EndsWith("/"))
                path += "/";
            int segmentIndex;
            // return each segment of the resource heirarchy
            while ((segmentIndex = path.LastIndexOf("/")) > 0)
            {
                path = path.Substring(0, segmentIndex);
                
                if(path.Contains("/api/"))
                    yield return path + "/";
            }
            yield break;
        }
    }
