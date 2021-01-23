        [TestInitialize]
        public void Initialize()
        {
           ...
            _httpHelper = new Mock<HttpHelper>(_logHelper.Object) { CallBase = true };
           ...
        }
        [TestMethod]
        public async Task SuccessStatusCode_WithAuthHeader()
        {
            ...
            _httpHelper.Setup(m => m.GetAsync(_uri, myHeaders)).Returns(
                Task<HttpResponseMessage>.Factory.StartNew(() =>
                {
                    return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(_testData))
                    };
                })
            );
            var result = await _httpHelper.Object.GetAsync<TestDTO>(...);
            Assert.AreEqual(...);
        }
