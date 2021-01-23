    public class Program
    {
        private readonly BlockingCollection<DirectoryInfo> collection = new BlockingCollection<DirectoryInfo>();
        public void Run()
        {
            Task.Factory.StartNew(() => CollectFolders(@"d:\www"));
            foreach (var dir in collection.GetConsumingEnumerable())
            {
                // Do something with the current folder
                // e.g. Console.WriteLine($"{dir.FullName}");
            }
        }
        
        public void CollectFolders(string path)
        {
            try
            {
                foreach (var dir in new DirectoryInfo(path).EnumerateDirectories("*", SearchOption.AllDirectories))
                {
                    collection.Add(dir);
                }
            }
            finally
            {
                collection.CompleteAdding();
            }
        }
    }
