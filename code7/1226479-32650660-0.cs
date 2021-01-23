    public static string GetSoundCloudData()
    {
        var request = (HttpWebRequest)WebRequest.Create("http://api.soundcloud.com/tracks/3/download");
        request.Method = "GET";
        request.UserAgent =
            "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:38.0) Gecko/20100101 Firefox/38.0";
        // Get the response.
        WebResponse response = request.GetResponse();
        // Display the status.
        if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
        {
            // Get the stream containing content returned by the server.
            var dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream, Encoding.UTF8);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Debug.WriteLine(responseFromServer);
    
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
    
        }
        else
        {
            response.Close();
            return null;
        }
    }
