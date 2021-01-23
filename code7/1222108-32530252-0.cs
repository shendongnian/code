    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(URL);
    using (WebResponse myResponse = await myRequest.GetResponseAsync())
    {
        using (StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8))
        {
            result = sr.ReadToEnd();
        }
    }
