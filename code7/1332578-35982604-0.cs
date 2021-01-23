     [TestMethod, Isolated]
     public void TestMethod1()
     {
         var httpRequest = new HttpRequest("", "http://www.monsite.com", "");
         var httpContext = new HttpContext(httpRequest, new HttpResponse(new StringWriter()));
         var httpApp = httpContext.Application;
    
         Isolate.Fake.AllInstances<HttpContext>();
    
         Isolate.WhenCalled(() => HttpContext.Current).WillReturn(httpContext);
         Isolate.WhenCalled(() => HttpContext.Current.Application).WillReturn(httpApp);
    
         HttpContext.Current.Application.Add("key1", "value1");
         HttpContext.Current.Application.Add("key2", "value2");
         HttpContext.Current.Application.Add("key3", "value3");
    
         Assert.AreEqual(3, HttpContext.Current.Application.Count);
         Assert.AreEqual("value1", HttpContext.Current.Application.Get("key1"));
    }
