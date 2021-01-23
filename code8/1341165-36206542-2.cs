    public class CustomWatcher
    {
        private readonly FileSystemWatcher watcher;
        public event EventHandler<FileSystemEventArgs> CreatedAndReleased;
 
        public CustomWatcher(string path)
        {
            watcher = new FileSystemWatcher(path, "*.jpg");
            watcher.Created += OnFileCreated;
            watcher.EnableRaisingEvents = true;
        }
        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            // Running the loop on another thread. That means the event
            // callback will be on the new thread. This can be omitted
            // if it does not matter if you are blocking the current thread.
            Task.Run(() =>
            {
                // Obviously some sort of timeout could be useful here.
                // Test until you can open the file, then trigger the CreeatedAndReleased event.
                while (!CanOpen(e.FullPath))
                {
                    Thread.Sleep(200);
                }
                OnCreatedAndReleased(e);
            });
        }
 
        private void OnCreatedAndReleased(FileSystemEventArgs e)
        {
            CreatedAndReleased?.Invoke(this, e);
        }
        private static bool CanOpen(string file)
        {
            FileStream stream = null;
            try
            {
                stream = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                return false;
            }
            finally
            {
                stream?.Close();
            }
            return true;
        }
    }
