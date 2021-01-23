    string URI = "http://www.myurl.com/post.php";
    try
    {
        using (WebClient wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            string HtmlResult = wc.UploadString(URI);
        }
    catch (WebException wex)
    {
    }
    catch (Exception ex)
    {
    }
