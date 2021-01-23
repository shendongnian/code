    string url = "https://www.coursera.org/course/money";
    HttpWebRequest postRequest = (HttpWebRequest)WebRequest.Create(url);
    postRequest.Method = "GET";
    postRequest.AllowAutoRedirect = true; //allowRedirect;
    postRequest.ServicePoint.Expect100Continue = true;
    HttpWebResponse postResponse = (HttpWebResponse) postRequest.GetResponse();
    int maxBytes = 1024*1024;
    int totalBytesRead = 0;
    var buffer = new byte[maxBytes];
    using (var s = postResponse.GetResponseStream())
    {
        int bytesRead;
        // read up to `maxBytes` bytes from the response
        while (totalBytesRead < maxBytes && (bytesRead = s.Read(buffer, 0, maxBytes)) != 0)
        {
            // Here you can save the bytes read to a persistent buffer,
            // or write them to a file.
            Console.WriteLine("{0:N0} bytes read", bytesRead);
            totalBytesRead += bytesRead;
        }
    }
    Console.WriteLine("total bytes read = {0:N0}", totalBytesRead);
