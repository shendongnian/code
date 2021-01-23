    try
    {
        using (WebResponse response = request.GetResponse())
        {
            Console.WriteLine("You will get error, if not do the proper processing");
        }
    }
    catch (WebException e)
    {
        using (WebResponse response = e.Response)
        {
            HttpWebResponse httpResponse = (HttpWebResponse) response;
            Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
            using (Stream data = response.GetResponseStream())
            using (var reader = new StreamReader(data))
            {
                // text is the response body
                string text = reader.ReadToEnd();
            }
        }
    }
