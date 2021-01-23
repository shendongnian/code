        [Test]
        public async Task get_should_succeed()
        {
            //arrange
            var url = string.Format("{0}{1}", BaseUrl, "controller");
            using(var httpServer = CreateHttpServer())
            using (var client = CreateHttpInvoker(httpServer))
            {
                using (var request = CreateHttpRequest(HttpMethod.Get, url))
                //act
                using (var response = await client.SendAsync(request, CancellationToken.None))
                {
                    //assert
                    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                }
            }
        }
