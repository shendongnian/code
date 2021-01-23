    protected override WebResponse GetWebResponse(WebRequest request)
    {
        WebResponse webResponse = base.GetWebResponse(request);
        webResponse.Headers["Content-Type"] = "text/xml; charset=iso-8859-15";
        return webResponse;
    }
