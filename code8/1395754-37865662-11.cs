    [TestMethod]
    public async Task HttpClient_Should_Get_OKStatus_From_Action_With_Multiple_Parameters() {
        var config = new HttpConfiguration();
        config.MapHttpAttributeRoutes();
        using (var server = new HttpServer(config)) {
            var client = new HttpClient(server);
            string url = "http://localhost/api/values/100/some+string+here";
            using (var response = await client.GetAsync(url)) {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
