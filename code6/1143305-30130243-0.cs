      private void check(string url, Action<string> act)
      {
        try
        {
            var request = (HttpWebRequest)WebRequest.Create(
            new Uri(url));
            request.BeginGetResponse(r =>
            {
                try
                {
                    var httpRequest = (HttpWebRequest)r.AsyncState;
                    var httpResponse = (HttpWebResponse)httpRequest.EndGetResponse(r);
                    using (var reader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var response = reader.ReadToEnd();
                    }
                }
                catch
                {
                    act("\u2612");
                }
            }, request);
        }
        catch
        {
            act(\u2612");
        }
        act("\u2611");
    }
