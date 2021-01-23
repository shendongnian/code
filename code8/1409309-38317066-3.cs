    try
    {
        var response = client.Get<Stream>(new ErrorStream());
        Assert.Fail();
    }
    catch (WebServiceException ex)
    {
        Assert.That(ex.IsAny400());
        Assert.That(!ex.IsAny500());
        Assert.That(ex.ErrorCode, Is.EqualTo("NotImplementedException"));
        Assert.That(ex.StatusCode, Is.EqualTo((int)HttpStatusCode.MethodNotAllowed));
    }
