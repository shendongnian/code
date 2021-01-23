        private void StartListening(string path)
        {
            var watch = new FileSystemWatcher();
            watch.Path = path;
            watch.Filter = "*.*";
            watch.Created += UpdateState;
            watch.Deleted += UpdateState;
        }
        void UpdateState(object sender, FileSystemEventArgs e)
        {
            MyButton.Enabled = File.Exists(@"C:\Folder\File.txt");
        }
