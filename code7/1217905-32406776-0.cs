    try {
    string s = new TimedWebClient {Timeout = 500}.DownloadString(URL);
    }
    catch(WebException e) {
    Console.WriteLine("Some kind of exception has appeared! (Timeout / Resource not available)");
    }
