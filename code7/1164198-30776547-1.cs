    public class ContentFile
        {
            public int ID { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51518/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.GetAsync("api/contentfile/1").Result;
                    var data = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(data);
                    Console.ReadKey();
                }
            }
        }
