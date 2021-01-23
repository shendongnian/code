    [TestMethod]
    public void TestMethod1()
    {
        HttpContext.Current = new HttpContext(new HttpRequest("", "http://blabla.com", "") {},
                                              new HttpResponse(new StringWriter()));
        HttpContext.Current.SetFakeSession();
        HttpContext.Current.Session["foo"] = 1;
        Assert.AreEqual(1, HttpContext.Current.Session["foo"]);
    }
