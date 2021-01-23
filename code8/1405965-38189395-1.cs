    [TestClass]
    public class OwinContextTests {
        [TestMethod]
        public void Mock_OwinContext_Request_Query_Should_Be_Queryable() {
            //Arrange
            var collection = new Dictionary<string, string[]>() {
                {"A", new[]{"1", "2", "3"} },
                {"B", new[]{"4", "5", "6"} }
            };
            //applying extension method
            var queryMock = new Mock<IReadableStringCollection>().AsQuaryableMock(collection);
            var requestMock = Mock.Create<IOwinRequest>();
            requestMock.Setup(m => m.Query).Returns(queryMock.Object);
            var contextMock = Mock.Create<IOwinContext>();
            contextMock.Setup(m => m.Request).Returns(requestMock.Object);
            var key = "B";
            var expected = collection[key];
            //Act
            var actual = SetUpQuery(contextMock.Object, key);
            //Assert
            Assert.IsNotNull(actual);
            CollectionAssert.AreEqual(expected, actual);
        }
        public static string[] SetUpQuery(IOwinContext context, string Key) {
            // Get the values from Querystring
            var values = context.Request.Query.Where(x => x.Key == Key).Select(x => x.Value).FirstOrDefault();
            return values;
        }
    }
