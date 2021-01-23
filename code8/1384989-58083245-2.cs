          class Program
        {
    
            static string url = "http://localhost:5000/api/DownloadZip";
    
            static async Task Main(string[] args)
            {
                var p = @"c:\temp1\test.zip";
    
                WebClient webClient = new WebClient();
                
                webClient.DownloadFile(new Uri(url), p);                       
    
                Console.WriteLine("ENTER to exit...");
                Console.ReadLine();
            }
        }
