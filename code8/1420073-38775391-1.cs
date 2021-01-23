    var dataContent = new MultipartFormDataContent();
    var keyValue = new ByteArrayContent( Encoding.ASCII.GetBytes("abcd") );
    dataContent.Add(keyValue, "key");
    using (var client = new HttpClient())
    {
        // open your file
        using (var fs = File.OpenRead(@"c:\path\to\audio.acc"))
        {
            // create StreamContent from the file   
            var fileValue = new StreamContent(fs);
            // add the name and meta-data 
            dataContent.Add(fileValue, "media", "audio.acc");
            HttpResponseMessage response = await client.PostAsync(
                      "http://yoursite.org", 
                      dataContent);
            HttpContent responseContent = response.Content;
            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                Console.WriteLine(await reader.ReadToEndAsync());
            }
        }
    }
