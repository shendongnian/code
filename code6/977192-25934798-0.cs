      static void Main(string[] args)
      {
                //some code here...
    
                // POST the request
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Console.Write(httpResponse.GetResponseStream());
                readMultipart(httpResponse).Wait();
        }
        async static Task readMultipart(HttpWebResponse httpResponse)
        {
             var content = new StreamContent(httpResponse.GetResponseStream());
            content.Headers.Add("Content-Type", httpResponse.ContentType);
            var multipart = await content.ReadAsMultipartAsync();
            String filename = "";
            String json = await multipart.Contents[0].ReadAsStringAsync();
            JObject o = JObject.Parse(json);
            filename = o["fileName"].ToString();
            using (var file = File.Create("C:\\testWS\\" + filename))
                await multipart.Contents[1].CopyToAsync(file);
        }
