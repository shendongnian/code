    [Test]
    public async System.Threading.Tasks.Task Integration_Get_Invalid_ReturnsUnauthorized()
    {
        // ARRANGE
        const string url = "/api/v2/authenticate/999/wrongName/wrongPassword";
        // ACT
        var result = await Get(url);
        // ASSERT
        Assert.IsFalse(result.HttpResponseMessage.IsSuccessStatusCode); 
    }
