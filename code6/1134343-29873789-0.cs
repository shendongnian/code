    class Program
    {
        static void Main(string[] args)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.dropbox.com/2-beta/files/get_metadata");
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization: Bearer <REDACTED>");
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(new {
                    path = "/avatar_501.png"
                }));
            }
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch (WebException e)
            {
                response = (HttpWebResponse)e.Response;
            }
            Console.WriteLine("Status code: {0}", (int)response.StatusCode);
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                Console.WriteLine(streamReader.ReadToEnd());
            }
            Console.ReadLine();
        }
    }
