    static void Main(string[] args)
    {
        Uri url = new Uri(@"http://content.warframe.com/dynamic/rss.php");
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        // MAGIC LINE GOES HERE \/
        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            
        // Assign the response object of HttpWebRequest to a HttpWebResponse variable.
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            using (Stream streamResponse = response.GetResponseStream())
            {
                using (StreamReader streamRead = new StreamReader(streamResponse))
                {
                    Char[] readBuff = new Char[2000];
                    int count = streamRead.Read(readBuff, 0, 2000);
                    while (count > 0)
                    {
                        String outputData = new String(readBuff, 0, count);
                        Console.Write(outputData);
                        count = streamRead.Read(readBuff, 0, 2000);
                    }
                }
            }
        }
        Console.ReadKey();
    }
