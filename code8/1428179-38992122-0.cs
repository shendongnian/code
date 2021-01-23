    using System.Collections.Specialized;
    using System.Text;
    using System.Web;
    namespace Testing
    {
        public static class NameValueCollectionExtension
        {
            public static string ToUtf8UrlEncodedQuery(this NameValueCollection nv)
            {
                StringBuilder sb = new StringBuilder();
                bool firstIteration = true;
                foreach (var key in nv.AllKeys)
                {
                    if (!firstIteration)
                        sb.Append("&");
                    sb.Append(HttpUtility.UrlEncode(key, Encoding.UTF8))
                        .Append("=")
                        .Append(HttpUtility.UrlEncode(nv[key], Encoding.UTF8));
                    firstIteration = false;
                }
                return sb.ToString();
            }
        }
    }
