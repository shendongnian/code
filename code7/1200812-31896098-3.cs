    namespace WebApiIdentityPoc.ConsoleOne
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Net;
        using System.Net.Http;
        using System.Net.Http.Headers;
        using System.Security.Principal;
        using System.Text;
        using System.Threading.Tasks;
        using Newtonsoft.Json;
        using WebApiIdentityPoc.Domain;
    
        public class Program
        {
            private static readonly string WebApiExampleUrl = "http://localhost:47503/api/Products/GetAllProducts"; /* check ProductsApp.csproj properties, "Web" tab, "IIS Express" settings if there is an issue */
    
            public static void Main(string[] args)
            {
                try
                {
                    System.Security.Principal.WindowsIdentity ident = System.Security.Principal.WindowsIdentity.GetCurrent();
                    if (null != ident)
                    {
                        Console.WriteLine("Will the Identity '{0}' Show up in IdentityWhiteListAuthorizationAttribute ???", ident.Name);
                    }
    
                    RunHttpClientExample();
                    RunWebClientExample();
                    RunWebClientWicExample();
                }
                catch (Exception ex)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    Exception exc = ex;
                    while (null != exc)
                    {
                        sb.Append(exc.GetType().Name + System.Environment.NewLine);
                        sb.Append(exc.Message + System.Environment.NewLine);
                        exc = exc.InnerException;
                    }
    
                    Console.WriteLine(sb.ToString());
                }
    
                Console.WriteLine("Press ENTER to exit");
                Console.ReadLine();
            }
    
            private static void RunWebClientExample()
            {
                /* some articles said that HttpClient could not pass over the credentials because of async operations, these were some "experiments" using the older WebClient.  Stick with HttpClient if you can */
                WebClient webClient = new WebClient();
                webClient.UseDefaultCredentials = true;
                string serviceUrl = WebApiExampleUrl;
                string json = webClient.DownloadString(serviceUrl);
                IEnumerable<Product> returnItems = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                ShowProducts(returnItems);
            }
    
            private static void RunWebClientWicExample()
            {
                /* some articles said that HttpClient could not pass over the credentials because of async operations, these were some "experiments" using the older WebClient.  Stick with HttpClient if you can */
                System.Security.Principal.WindowsIdentity ident = System.Security.Principal.WindowsIdentity.GetCurrent();
                WindowsImpersonationContext wic = ident.Impersonate();
                try
                {
                    WebClient webClient = new WebClient();
                    webClient.UseDefaultCredentials = true;
                    string serviceUrl = WebApiExampleUrl;
                    string json = webClient.DownloadString(serviceUrl);
                    IEnumerable<Product> returnItems = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                    ShowProducts(returnItems);
                }
                finally
                {
                    wic.Undo();
                }
            }
    
            private static void RunHttpClientExample()
            {
                IEnumerable<Product> returnItems = null;
    
                HttpClientHandler handler = new HttpClientHandler()
                {
                    UseDefaultCredentials = true, PreAuthenticate = true
                };
    
                ////////WebRequestHandler webRequestHandler = new WebRequestHandler();
                ////////webRequestHandler.UseDefaultCredentials = true;
                ////////webRequestHandler.AllowPipelining = true;
                ////////webRequestHandler.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequired;
                ////////webRequestHandler.ImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Identification;
    
                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                    string serviceUrl = WebApiExampleUrl;
    
                    HttpResponseMessage response = client.GetAsync(new Uri(serviceUrl)).Result;
    
                    var temp1 = response.ToString();
                    var temp2 = response.Content.ReadAsStringAsync().Result;
    
                    if (response.IsSuccessStatusCode)
                    {
                        Task<IEnumerable<Product>> wrap = response.Content.ReadAsAsync<IEnumerable<Product>>();
                        if (null != wrap)
                        {
                            returnItems = wrap.Result;
                        }
                        else
                        {
                            throw new ArgumentNullException("Task<IEnumerable<Product>>.Result was null.  This was not expected.");
                        }
                    }
                    else
                    {
                        throw new HttpRequestException(response.ReasonPhrase + " " + response.RequestMessage);
                    }
                }
    
                ShowProducts(returnItems);
            }
    
            private static void ShowProducts(IEnumerable<Product> prods)
            {
                if (null != prods)
                {
                    foreach (Product p in prods)
                    {
                        Console.WriteLine("{0}, {1}, {2}, {3}", p.Id, p.Name, p.Price, p.Category);
                    }
    
                    Console.WriteLine(string.Empty);
                }
            }
        }
    }
