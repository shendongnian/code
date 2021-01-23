    private CookieContainer sessionCookies = new CookieContainer();
    public static string GetWebText(string url) {
       HttpWebRequest request = HttpWebRequest.Create();
       request.CookieContainer = this.sessionCookies; // loading cookies in
       WebResponse response = request.GetResponse();
       // now we need to store cookies received from server into the sessionCookies variable
       this.sessionCookies = response.GetCoookies(); // GetCoookies() method or similar, check C# specification
       ...
       return htmlText;
    }
