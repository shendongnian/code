    public class TestClass {
        private class TestStartup : Startup {
            public override void Configuration(IAppBuilder app) {
                // do your web api, IoC, etc setup here
                var config = new HttpConfiguration();
                config.MapHttpAttributeRoutes();
                // ...etc
                app.UseWebApi(config);
            }
        }
    
        [Test]
        public void MyTest() {
            // arrange
            using (var server = TestServer.Create<TestStartup>()) {
    
                // act
                var response = server.CreateRequest("api/someroute/").GetAsync().Result;
    
                // verify
                Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            }
        }
    }
