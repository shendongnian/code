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
    
        private dynamic newTestRegistration(string mobileCountryCode = "44", string fullMobile = "447900123456", string firstName = "Scooby", string surname = "Doo", DateTime? registeredAt = null)
        {
            return new { mobileCountryCode = mobileCountryCode, fullMobile = fullMobile, firstName = firstName, surname = surname, registeredAt = (registeredAt == null ? DateTime.UtcNow : (DateTime)registeredAt) };
        }
    
            [Fact]
            public async Task Return422WhenCountryCodeTooLong() 
            {
                object requestData = newTestRegistration(mobileCountryCode);
                var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
                // Exercise the fluent validation
                var response = await _client.PostAsync("api/appusers/registration", content);
                Assert.Equal(422, (int) response.StatusCode);
            }
        }
    }
