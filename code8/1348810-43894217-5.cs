    [TestMethod]
        public async Task GetProductsReturnsDeserializedXmlXopData()
        {
            // Arrange
            var mockMessageHandler = new Mock<IMockHttpMessageHandler>();
            // Set up Mock behavior here.
            var auroraClient = new AuroraClient(new MockHttpMessageHandler(mockMessageHandler.Object));
            // Act
            // Assert
        }
