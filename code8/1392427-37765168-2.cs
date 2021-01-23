    [TestClass]
    public class FBMessageControllerTests {
        [TestMethod]
        public async Task HttpClient_Should_Get_OKStatus_From_Post_To_FBMessage() {
            using (var server = new TestServer()) {
                var config = server.Configuration;
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
                
                var handlerMock = new Mock<IExceptionHandler>();
                handlerMock
                    .Setup(m => m.HandleAsync(It.IsAny<ExceptionHandlerContext>(), It.IsAny<System.Threading.CancellationToken>()))
                    .Callback<ExceptionHandlerContext, CancellationToken>((context, token) => {
                        var innerException = context.ExceptionContext.Exception;
                        Assert.Fail(innerException.Message);
                    });
                config.Services.Replace(typeof(IExceptionHandler), handlerMock.Object);
                
                var client = server.CreateClient();
                string url = "http://localhost/api/fbMessage";
                var body = new { body = "Hello World" };
                using (var response = await client.PostAsJsonAsync(url, body)) {
                    var message = await response.Content.ReadAsStringAsync();
                    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, message);
                }
            }
        }
        [Authorize]
        public class FBMessageController : ApiController {
            public string Get() {
                return null;
            }
            [System.Web.Mvc.ChildActionOnly]
            public SendResponse Send(ComplexType test) {
                return null;
            }
            [System.Web.Mvc.ChildActionOnly]
            public SendResponse SendImage(string x, string y) {
                return null;
            }
            [HttpPost]
            public SendResponse Post([FromBody]AnotherComplexType body) {
                return null;
            }
            public void Put(string gbody) {
                return;
            }
            public void Delete(string body) {
                return;
            }
        }
        public class SendResponse { }
        public class ComplexType {  }
        public class AnotherComplexType {  }
    }
