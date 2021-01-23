    class Program
    {
        private static HttpClient client = new HttpClient();
        private static TableControllerSelector selector;
        private const string ServiceUrl = "http://localhost:12345";
        private const string connectionString = @"Server=MYSQLSERVER;Database=AdventureWorks2014;Integrated Security=SSPI";
        static void Main(string[] args)
        {
            using (WebApp.Start(ServiceUrl, Configuration))
            {
                Console.WriteLine("Server is listening at {0}", ServiceUrl);
                RunSample();
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();
            }
        }
        public static void Configuration(IAppBuilder builder)
        {
            HttpConfiguration configuration = new HttpConfiguration();
            // create a special dynamic controller selector
            selector = new TableControllerSelector(configuration);
            IEdmModel  model = TableController.GetEdmModel(connectionString, selector);
            configuration.Services.Replace(typeof(IHttpControllerSelector), selector);
            configuration.MapODataServiceRoute("odata", "odata", model); // needs using System.Web.OData.Extensions
            builder.UseWebApi(configuration);
        }
        public static void RunSample()
        {
            Console.WriteLine("1. Get Metadata.");
            GetMetadata();
            Console.WriteLine("\n2. Get Entity Set.");
            using (var dbReader = new DatabaseReader(connectionString, "System.Data.SqlClient"))
            {
                foreach (var table in dbReader.AllTables())
                {
                    Console.WriteLine("\n 2.1 Get Entity Set '" + table.Name  + "'.");
                    GetEntitySet(table.Name);
                }
            }
        }
        public static void GetMetadata()
        {
            HttpResponseMessage response = client.GetAsync(ServiceUrl + "/odata/$metadata").Result;
            PrintResponse(response);
        }
        public static void GetEntitySet(string tableName)
        {
            HttpResponseMessage response = client.GetAsync(ServiceUrl + "/odata/" + tableName + "?$filter=Id eq 1").Result;
            PrintResponse(response);
        }
        public static void PrintResponse(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Response:");
            Console.WriteLine(response);
            if (response.Content != null)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
