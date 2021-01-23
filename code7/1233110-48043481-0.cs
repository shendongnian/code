           //Arrange
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("http://dontcare.ch")
                .Respond("application/txt", "Content from MockedHttpContent"); // Respond with content
            var client = mockHttp.ToHttpClient();
            //Act
            var response = await client.GetAsync("http://dontcare.ch");
            var result = await response.Content.ReadAsStringAsync();
            //Assert
            Assert.AreEqual("Content from MockedHttpContent", result);
