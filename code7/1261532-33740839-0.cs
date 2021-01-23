    [TestMethod]
    [TestCategory("Unit")]
    public async Task Test_MyMethod()
    {
        using (var server = TestServer.Create<TestStartup>())
        {
            //Arrange
            server.BaseAddress = new Uri("https://localhost");
            var jsonBody = new JsonMyRequestObject();
            var request = server.CreateRequest("/api/v1/MyMethod")
                .And(x => x.Method = HttpMethod.Post)
                .And(x => x.Content = new StringContent(JsonConvert.SerializeObject(jsonBody), Encoding.UTF8, "application/json"));
            //Act
            var response = await request.PostAsync();
            var jsonResponse =
                JsonConvert.DeserializeObject<JsonMyResponseObject>(await response.Content.ReadAsStringAsync());
            //Assert
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
