    [TestClass]
    public class AttributeRoutingValuesTests {
        [TestMethod]
        public async Task Attribute_Routing_Values_In_Url_Should_Bind_Parameter_FromBody() {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            using (var server = new HttpTestServer(config)) {
                var client = server.CreateClient();
                string url = "http://localhost/api/Products/5";
                var data = new UpdateProductModel {
                    Name = "New Name" // NB: No ProductId in data
                };
                using (var response = await client.PostAsJsonAsync(url, data)) {
                    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                }
            }
        }
    }
