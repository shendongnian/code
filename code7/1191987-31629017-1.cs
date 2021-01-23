    $code = @"
    using System.Security.Policy;
    using System.IO;
    using System.Net;
    public class MySharepointTools 
    {
        public void UploadFile(System.String url, System.Net.CookieContainer cookie, System.Byte[] data)
        {
            System.Net.ServicePointManager.Expect100Continue = false; 
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest; 
            request.Method = "PUT"; 
            request.Accept = "*/*"; 
            request.ContentType = "multipart/form-data; charset=utf-8"; 
            request.CookieContainer = cookie; request.AllowAutoRedirect = false; 
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)"; 
            request.Headers.Add("Accept-Language", "en-us"); 
            request.Headers.Add("Translate", "F"); request.Headers.Add("Cache-Control", "no-cache"); request.ContentLength = data.Length; 
            using (Stream req = request.GetRequestStream()) 
            { req.Write(data, 0, data.Length); } 
            HttpWebResponse response = (HttpWebResponse)request.GetResponse(); 
            Stream res = response.GetResponseStream(); 
            StreamReader rdr = new StreamReader(res); 
            string rawResponse = rdr.ReadToEnd(); 
            response.Close();
            rdr.Close();
        }
    }
    "@
    Add-Type -TypeDefinition $code -Language CSharp 
    $tools = New-Object MySharepointTools
