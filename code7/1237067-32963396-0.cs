    Timer t = new Timer(60000);
    t.Elapsed += (sender, e) =>
    {
        try
        {
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create("http://google.com");
            using (HttpWebResponse httpRes = (HttpWebResponse) httpReq.GetResponse())
            {
                if (httpRes.StatusCode != HttpStatusCode.OK)
                {
                    File.AppendAllText(@"C:\Error.txt",
                        string.Format("Server error: {0} {1}",
                         httpRes.StatusCode, httpRes.StatusDescription));
                }
            }
        }
        catch (Exception exc)
        {
            File.AppendAllText(@"C:\Error.txt", "Error: "+exc.ToString());
        }
    };
    t.Start();
