    using System;
    using System.Threading.Tasks;
    using Xunit;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.AspNetCore.Hosting;
    using System.Text;
    using System.Net.Http;
    using System.Net;
    using Newtonsoft.Json;
    using System.IO;
    
    namespace Tests
    {
        public class MyAPIRequestsShould
        {
            IWebHostBuilder _webHostBuilder;
            TestServer _host;
            HttpClient _client;
    
            public MyAPIRequestsShould()
            {
                string curDir = Directory.GetCurrentDirectory();
                _webHostBuilder = new WebHostBuilder().UseContentRoot(curDir).UseStartup<MyApi.Startup>();
                _host = new TestServer(_webHostBuilder);
                _client = _host.CreateClient();
            }
    
            private object newTestRegistration()
            {
                return new { mobileCountryCode = "44", fullMobile = "447999123456", firstName = "Scooby", surname = "Doo", registeredAt = DateTime.Now };
            }
    
            [Fact]
            public async Task Return422WhenCountryCodeTooLong() 
            {
                var requestData = newTestRegistration();
                requestData.mobileCountryCode = "55555"; // exercise the fluent validation
                var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("api/appusers/registration", content);
                Assert.Equal(422, (int) response.StatusCode);
            }
        }
    }
