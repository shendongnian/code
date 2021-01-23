    void Main()
    {
    
        var formSerializer = new FormEncodedSerializer();
        formSerializer.Add("key", "value");
        formSerializer.Add("foo", "rnd");
        formSerializer.Add("bar", "random");
    
        var uri = @"http://example.com";
        var contentType = @"application/x-www-form-urlencoded";
        var postData = formSerializer.Serialize();
        var http = new Http();
        
        Console.WriteLine (http.Post(uri, postData, contentType));
    }
    
    
    public class Http
    {
        public string Post(string url, string data, string format)
        {
            var content = Encoding.UTF8.GetBytes(data);
            var contentLength = content.Length;
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ServicePoint.Expect100Continue = false;
            request.Method = "POST";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentType = format;
            request.ContentLength = contentLength;
            
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(content, 0, content.Length);
            }
            
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                return reader.ReadToEnd();
            }
        }
    }`
    public class FormEncodedSerializer
    {
        private Dictionary<string, string> formKeysPairs;
    
        public FormEncodedSerializer(): this(new Dictionary<string, string>())
        {
        }
        
        public FormEncodedSerializer(Dictionary<string, string> kvp)
        {
            this.formKeysPairs = kvp;
        }
        
        public void Add(string key, string value)
        {
            formKeysPairs.Add(key, value);
        }  
        
        public string Serialize()
        {
            return string.Join("", this.formKeysPairs.Select(f => string.Format("&{0}={1}", f.Key,f.Value))).Substring(1);
        }
        
        public void Clear()
        {
            this.formKeysPairs.Clear();
        }  
    }
