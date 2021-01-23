    // handle <img> tags in any System.Web.UI.Control (GridView) with:
    // 1. base64 Data URI scheme - https://en.wikipedia.org/wiki/Data_URI_scheme
    // 2. absolute URLs on a remote/local server 
    // 3. relative URLs on local server (DEFAULT)
    public class ImageHander : IImageProvider
    {
        public string BaseUri { get; set; }
        public static Regex Base64 = new Regex(
            @"^data:image/(?<mediaType>[^;]+);base64,(?<data>.*)",
            RegexOptions.Compiled
        );
    
        // alias: using iTextImage = iTextSharp.text.Image;
        public iTextImage GetImage(string src,
            IDictionary<string, string> attrs,
            ChainedProperties chain,
            IDocListener doc)
        {
            Match match;
            // [1]
            if ((match = Base64.Match(src)).Length > 0)
            {
                return iTextImage.GetInstance(
                    Convert.FromBase64String(match.Groups["data"].Value)
                );
            }
    
            // [2]
            if (!src.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                src = HttpContext.Current.Server.MapPath(
                    new Uri(new Uri(BaseUri), src).AbsolutePath
                ); 
            }
            return iTextImage.GetInstance(src);
        }
    }
