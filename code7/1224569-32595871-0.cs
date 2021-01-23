    var http = (HttpWebRequest)WebRequest.Create("http://www.metacritic.com/movie/boyhood");
    http.UserAgent = "Mozilla.. Haha, not really.";
    try {
        var response = http.GetResponse();
        var stream = response.GetResponseStream();
        var sr = new StreamReader(stream);
        var content = sr.ReadToEnd();
        var wr = new StreamWriter("scrap.txt");
        wr.WriteLine(content);
        wr.Close();
        Debug.WriteLine(content);
        response.Close();
    }
    catch (WebException ex)
    {
        //Get the returned data to see what kind of error occured
        string s = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
        Debug.WriteLine(s);
    }
