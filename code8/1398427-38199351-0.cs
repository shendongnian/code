    [Test]
    public async Task InitializeShimHttpWebResponse()
    {
        using (ShimsContext.Create())
        {
            ShimWebRequest.AllInstances.GetResponseAsync = (x) =>
            {
    /* you can replace the var with WebResponse if you aren't going to set any behavior */
                var res = new ShimHttpWebResponse(); 
                return Task.FromResult((WebResponse)res);
            };
            ShimWebRequest.CreateString = uri =>
            {
                WebRequest req = new ShimFileWebRequest();
                return req;
            };
            var request = WebRequest.Create("");
            var response = await request.GetResponseAsync() as HttpWebResponse;
            Assert.IsNotNull(response);
        }
    }
