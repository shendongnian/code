    public partial class MiscUnitTests {
        [TestClass]
        public class HttpClientIntegrationTests : MiscUnitTests {
            
            [TestMethod]
            public async Task HttpClient_Should_Get_OKStatus_From_Products_Using_InMemory_Hosting() {
                var config = new HttpConfiguration();
                //configure web api
                config.MapHttpAttributeRoutes();
                using (var server = new HttpServer(config)) {
                    var client = new HttpClient(server);
                    string url = "http://localhost/api/product/hello/";
                    var request = new HttpRequestMessage {
                        RequestUri = new Uri(url),
                        Method = HttpMethod.Get
                    };
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (var response = await client.SendAsync(request)) {
                        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                    }
                }
            }
        }
        public class ProductController : ApiController {
            [HttpGet]
            [Route("api/product/hello/")]
            public IHttpActionResult Hello() {
                return Ok();
            }
        }
    }
