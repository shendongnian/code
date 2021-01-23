    using (var fs = new FileStream("tif file", FileMode.Open))
    {
        var request = (HttpWebRequest)WebRequest.Create("address");
        request.Method = "POST";
        request.ContentLength = fs.Length;
        using (Stream postStream = request.GetRequestStream())
        {
            // Write the other contents you wanted to write here
            // ...
            // CopyTo uses a buffer of 4096 bytes by default, so it will
            // only read 4096 bytes into memory at a time.
            fs.CopyTo(postStream);
            postStream.Close(); // Not sure if necessary since we're in a using block
        }
        using (HttpWebResponse response = request.GetResponse()) // might need to cast to HttpWebRequest
        using (Stream responseStream = response.GetResponseStream())
        using (var streamReader = new StreamReader(responseStream))
        {
            string response = Encoding.UTF8.GetString(streamReader.ReadToEnd());
            // Stuff with the response
        }
    }
