    var baseAddress = new Uri("https://wttv.click-tt.de/");
    var cookieContainer = new CookieContainer();
    using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
    using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
    {
        //usually i make a standard request without authentication, eg: to the home page.
        //by doing this request you store some initial cookie values, that might be used in the subsequent login request and checked by the server
        var homePageResult = client.GetAsync("/");
        homePageResult.Result.EnsureSuccessStatusCode();
        var content = new FormUrlEncodedContent(new[]
        {
            //the name of the form values must be the name of <input /> tags of the login form, in this case the tag is <input type="text" name="username">
            new KeyValuePair<string, string>("username", "username"),
            new KeyValuePair<string, string>("password", "password"),
        });
        var loginResult = client.PostAsync("/cgi-bin/WebObjects/nuLigaTTDE.woa/wa/teamPortrait?teamtable=1673669&pageState=rueckrunde&championship=SK+Bez.+BB+13%2F14&group=204559", content).Result;
        loginResult.EnsureSuccessStatusCode();
        //make the subsequent web requests using the same HttpClient object
    }
