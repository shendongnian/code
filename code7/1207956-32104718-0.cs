    private CookieContainer sessionCookies = new CookieContainer();
    public void MakeRequest() {
        HttpWebRequest request = HttpWebRequest.Create();
        request.CookieContainer = this.sessionCookies;
        // your code here
        request.GetResponse();
    }
