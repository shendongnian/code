    public class Scraper : IDisposable
    {
        private readonly BlockingCollection<Action> tasks;
        private readonly IList<BackgroundWorker> workers;
        public Scraper(IList<Uri> urls, int numberOfThreads)
        {
            for (var i = 0; i < urls.Count; i++)
            {
                var url = urls[i];
                tasks.Add(() => Scrape(url));
            }
            for (var i = 0; i < numberOfThreads; i++)
            {
                var worker = new BackgroundWorker();
                worker.DoWork += (sender, args) =>
                {
                    Action task;
                    while (tasks.TryTake(out task))
                    {
                        task();
                    }
                };
                workers.Add(worker);
                worker.RunWorkerAsync();
            }
        }
        public void Scrape(Uri url)
        {
            Console.WriteLine("Scraping url {0}", url);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
