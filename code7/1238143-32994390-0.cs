    //  cookies
    CookieContainer cookieContainer = new CookieContainer();
    
    // make one call to the root of the website
    // to get the cookies set
    Uri uri = new Uri(@"http://www.filmweb.pl");
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
    request.CookieContainer = cookieContainer;
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    
    var s = response.GetResponseStream();
    var sr = new StreamReader(s);
    // linqpad
    sr.ReadToEnd().Dump(); // to check for errors
    
    // we have cookies now
    // do the deep link fetch
    uri = new Uri(@"http://www.filmweb.pl/film/Igrzyska+%C5%9Bmierci%3A+Kosog%C5%82os.+Cz%C4%99%C5%9B%C4%87+1-2014-626983");
    request = (HttpWebRequest)WebRequest.Create(uri);
    request.CookieContainer = cookieContainer;
    response = (HttpWebResponse)request.GetResponse();
    
    //store the result
    var f = File.Create("pagecontent.txt");
    response.GetResponseStream().CopyTo(f);
