    public class MyTestCase {
            public static Mock<IAirportService> MockObj { get; set; }
            private class TestStartup : Startup {
                public override void Configuration(IAppBuilder app) {
                    var httpConfig = new HttpConfiguration();
                    // this now returns ContainerBuilder instead of the container
                    var builder = AutofacSetup.Register(httpConfig)
                    // register your mock, change this to whatever lifetime scope you need
                    var moqAirportCollection = new AirportCollection();
                    moqAirportCollection.Airports = new List<Airport>{new Airport{IATA = "moq",Name = "moqName"}};
                    var mock = AutoMock.GetLoose()
                    var moqObj = MockObj = mock.Mock<IAirportService>()
                                               .Setup(x => x.GetAirports())
                                               .Returns(moqAirportCollection);
                    
                    builder.RegisterInstance(moqObj).As<IAirportService>();
                    
            
                    container = builder.Build();
                    WebApiConfig.Register(httpConfig);
    
    
                    appBuilder.UseAutofacMiddleware(container);
                    appBuilder.UseAutofacWebApi(httpConfig);
                    appBuilder.UseWebApi(httpConfig);
                }
            }
    
            [Test]
            public void Request_all_airports()
            {    
               using (var server = WebApp.Start<Startup>())
               {
                   var response = 
                       server.CreateRequest("/api/airport/get")
                             .GetAsync()
                             .Result;
                    var body = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<AirportCollection>(body);
                    // assert something
                }
            }
        }
