    using System;
    using System.Collections.Specialized;
    using System.Net;
    using System.Threading.Tasks;
    
    namespace MyNamespace
    {
        public class Requests
        {
            public static void Main()
            {
                RunAsync().Wait();
            }
    
            static async Task RunAsync()
            {
                using (var client = new WebClient())
                {
                    var postData = new NameValueCollection()
                    {
                        {"Topics001", "Batman"},
                        {"Account", "5"}
                    };
    
                    var uri = new Uri("http://localhost:8080/");
                    var response = await client.UploadValuesTaskAsync(uri, postData);
    
                    var result = System.Text.Encoding.UTF8.GetString(response);
                }
            }
        }
    }
