    private HttpWebRequest request(){
        try{
            System.Uri uri = new System.Uri("http://localhost:8080/...");
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Timeout = 15000;
            request.KeepAlive = true ;
            request.Method= "GET";
            Cookie Authentication = new Cookie("Session" , "09iubasd");
            Authentication.Domain = uri.Host;
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(Authentication);
            request.Headers.Add("testting", "hascome");
            return request;
        }catch(System.Exception ex){
            Debug.Log("[Exception]" + ex);
            throw ex;
        }
    }
