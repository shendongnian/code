    public class PostData
    {
        public string aStr { get; set; }
    }
    
---
    [WebInvoke(Method = "POST",
     ResponseFormat = WebMessageFormat.Json,
     BodyStyle = WebMessageBodyStyle.Bare,
     UriTemplate = "?s={aStr}")]
        string Test(PostData data);
