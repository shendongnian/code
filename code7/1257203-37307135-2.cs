    public ActionResult ProductSearch(string search)
    {
        var authentication = new AmazonAuthentication();
        authentication.AccessKey = "accesskey";
        authentication.SecretKey = "secretkey";
        var wrapper = new AmazonWrapper(authentication, AmazonEndpoint.DE);
        var result = wrapper.Search(search);
        return View(result);
    }
