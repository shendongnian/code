    using Microsoft.Owin;
    using Microsoft.Owin.Hosting;
    using Owin;
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace StackOverflowAnswer
    {
        class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.Use<RespondToRequestMiddleware>();
            }
        }
    
        class RespondToRequestMiddleware : OwinMiddleware
        {
            public RespondToRequestMiddleware(OwinMiddleware next)
                : base(next)
            {
    
            }
    
            public async override Task Invoke(IOwinContext context)
            {
                // Perform request stuff...
                // Could verify that the request Content-Type == application/json
                // Could verify that the request method was POST.
                bool isPost = context.Request.Method == "POST";
                string test = null;
                if (isPost)
                {
                    using (StreamReader reader = new StreamReader(context.Request.Body))
                    {
                        test = await reader.ReadToEndAsync();
                    }
                }
    
                await Next.Invoke(context); // pass off request to the next middleware
    
                if (isPost)
                {
                    // Perform response stuff...
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync(test);
                    Console.WriteLine("Response given to a request.");
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                string url = "http://localhost:5000/";
                using (WebApp.Start<Startup>(url))
                {
                    Console.WriteLine($"Listening on {url}...");
    
                    using (HttpClient httpClient = new HttpClient())
                    {
                        string json = "{\"key\":\"value\", \"otherKey\":\"secondValue\"}";
                        // Typically use the extensions in System.Net.Http.Formatting in order to post a strongly typed object with HttpClient.PostAsJsonAsync<T>(url)
                        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = httpClient.PostAsync(url, content).Result; // IMPORTANT: use await in an async method in the real world.
    
                        if (response.IsSuccessStatusCode)
                        {
                            string responseJson = response.Content.ReadAsStringAsync().Result; // Again: use await in an async method in the real world.
                            Console.WriteLine(responseJson); // In your method, return the string.
                        }
                        else
                        {
                            Console.WriteLine($"Unsuccessful {response.StatusCode} : {response.ReasonPhrase}");
                        }
                    }
    
                    Console.ReadLine(); // keep console from closing so server can keep listening.
                }
            }
        }
    }
