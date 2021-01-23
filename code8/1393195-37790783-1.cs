    class Program
    {
        static void Main(string[] args)
        {
            var task = LoadUrl(new Uri("http://www.google.com"));
            task.Wait();
            Console.WriteLine(Encoding.Default.GetString(task.Result));
            Console.ReadKey();
        }
        static async Task<byte[]> LoadUrl(Uri uri)
        {
            using (var webclient = new WebClient())
            {
                using (var stream = webclient.OpenRead(uri))
                {
                    return await Task.Run(new Func<byte[]>(() => { return webclient.DownloadData(uri); }));
                }
            }
        }
    }
