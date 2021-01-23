    public void Test1()
    {
        HttpRequest request = new HttpRequest(null, "http://tempuri.org", null);
        HttpResponse response = new HttpResponse(null);
        HttpContext httpContext = new HttpContext(request, response);
        
        httpContext.Request.Cookies.Add(new HttpCookie("cookieName"));
        
        MyClass cls = new MyClass(httpContext);
        cls.SomeMethod();
    }
