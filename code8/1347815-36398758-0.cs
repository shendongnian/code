    static void Main(string[] args) {
        String file_name = Path.GetRandomFileName();
        String full_path = Environment.ExpandEnvironmentVariables(
            Path.Combine(@"%LocalAppData%\Temp", file_name));
    
        using (WebClient client = new WebClient()) {
            client.Credentials = CredentialCache.DefaultCredentials;
            var proxyUri = WebRequest.GetSystemWebProxy()
                .GetProxy(new Uri("https://yadi.sk/i/jPScGsw9qiSXU"));
            client.Proxy = new WebProxy(proxyUri);
    
            try {                    
                client.DownloadFile("https://yadi.sk/i/jPScGsw9qiSXU", full_path);
            }
            catch (Exception ex) {
                // The remote server returned an error: (502) Bad Gateway.
                Console.WriteLine(ex.Message);
            }
        }
        Console.WriteLine("Press any key for exit.");
        Console.ReadKey();
    }
