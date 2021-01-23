    internal static string createAPage(string space, string title, string body, string objectType, int ancestorId = -1)
            {
                string json = string.Empty;
                try
                {
                    CreateContentWithParentJson createContentWithParentJson = JsonConvert.DeserializeObject<CreateContentWithParentJson>(_jsonCreatePageWithParentSample);
                    createContentWithParentJson.space.key = space;
                    createContentWithParentJson.title = title;
                    body = body.Replace("&", "&amp;");
                    createContentWithParentJson.body.storage.value = "<p>" + body + "</p>";
                    Ancestor a = new Ancestor();
                    a.id = ancestorId;
                    createContentWithParentJson.ancestors = new List<Ancestor>();
                    createContentWithParentJson.ancestors.Add(a);
                    json = JsonConvert.SerializeObject(createContentWithParentJson, Utils.getJsonSettings());
    
            }
            catch (Exception) {  // handle exception 
            }
            return Utils.contentPost(json, _baseUrl);
        }
      internal static string contentPost(string postData, string url, string method = "POST")
            {
                string encodedCred = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(ConfAPI._confUser + ":" + ConfAPI._confPass));
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers.Add("Authorization", "Basic " + encodedCred);
                request.Headers.Add("X-Atlassian-Token", "no-check");
                request.Method = method;
                request.Accept = "application/json";
                request.ContentType = "application/json";
    
                // request.KeepAlive = false;
                if (postData != null)
                {
                    byte[] data = Encoding.UTF8.GetBytes(postData);
                    request.ContentLength = data.Length;
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }
                WebResponse response;
    
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException e)
                {
                    return e.Message + " " + e.StackTrace.ToString();
                }
    
                var responsestring = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return responsestring;
            }
      public class CreateContentWithParentJson
        {
            public string type { get; set; }
            public string title { get; set; }
            public List<Ancestor> ancestors { get; set; }
            public Space space { get; set; }
            public Body body { get; set; }
        }
     internal static string _baseUrl = "http://localhost:8090/rest/api/content";
     internal static string _jsonCreatePageWithParentSample = @"{'type':'page','title':'new page', 'ancestors':[{'id':456}], 'space':{'key':'TST'},'body':{'storage':{'value':'<p>This is a new page</p>','representation':'storage'}}}";
