    using (var fs = new FileStream("tif file", FileMode.Open))
    {
        var request = (HttpWebRequest)WebRequest.Create("address");
        request.Method = "POST";
        request.ContentLength = fs.Length;
        using (Stream postStream = request.GetRequestStream())
        {
            // Write the other contents you wanted to write here
            // ...
            fs.CopyTo(postStream); // CopyTo uses a buffer of 81920 bytes by default
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
