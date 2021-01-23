    public class DataFiles : IDisposable {
        public FileSystemWatcher filewatcher;
        private readonly object fileListLock = new object();
        // you don't need public setter on this
        public ObservableCollection<Files> Fileslist { get; } = new ObservableCollection<Files>();
        // pass path here, no need to use property
        public void InitializeFiles(string path) {
            // dispose existing watcher, if any
            DisposeWatcher();
            // Create a new FileSystemWatcher
            filewatcher = new FileSystemWatcher();
            // Set filter to only catch XAL files
            filewatcher.Filter = "*.txt";
            // Set the path
            filewatcher.Path = path;
            // Subscribe to the Created event
            filewatcher.Created += new FileSystemEventHandler(FileOnchanged);
            filewatcher.Changed += new FileSystemEventHandler(FileOnchanged);
            filewatcher.Deleted += new FileSystemEventHandler(FileOnchanged);
            filewatcher.Renamed += new RenamedEventHandler(FileOnRenamed);
            // don't RefreshFilesList on UI thread, that might take some time and will block UI
            Task.Run(() => RefreshFilesList());
            // Enable the FileSystemWatcher events
            filewatcher.EnableRaisingEvents = true;
        }
        private void FileOnchanged(object sender, FileSystemEventArgs e) {
            // lock here to avoid race conditions with RefreshFilesList
            lock (fileListLock) {
                // better use dictionary to avoid looping over all files
                // but looping is still much better than rebuilding whole list
                var file = Fileslist.FirstOrDefault(c => String.Equals(c.FullPath, e.FullPath, StringComparison.OrdinalIgnoreCase));
                if (file != null) {
                    if (e.ChangeType == WatcherChangeTypes.Deleted)
                        ; // delete
                    else
                        ; // update file properties
                }
                else {
                    // add new, unless event is delete
                }
            }
        }
        private void FileOnRenamed(object sender, RenamedEventArgs e) {
            lock (fileListLock) {
                // better use dictionary to avoid looping over all files
                var file = Fileslist.FirstOrDefault(c => String.Equals(c.FullPath, e.OldFullPath, StringComparison.OrdinalIgnoreCase));
                if (file != null) {
                    file.FullPath = e.FullPath;
                }
                else {
                    // add new
                }
            }
        }
        public void RefreshFilesList() {
            // you need to lock here, because there is a race condition between this method and FileOnRenamed \ FileOnChanged, 
            // and you might lose some updates or get duplicates. 
            lock (fileListLock) {
                // update ObservableCollection on UI thread
                OnUIThreadDo(() => {
                    Fileslist.Clear();
                });
                DirectoryInfo dir = new DirectoryInfo(filewatcher.Path);
                int nof = 0;
                
                var files = new List<Files>();
                // just use EnumerateFiles
                foreach (FileInfo file in dir.EnumerateFiles("*.txt")) {
                    nof++;
                    int tmp = nof;
                    // if you are working with UI (that is most likely the case if you use ObservableCollection) -
                    // you need to update that collection from UI thread if you have bound controls                    
                    files.Add(new Files() {
                        FileId = tmp,
                        FullPath = file.FullName,
                        FileChanged = file.LastWriteTime,
                        FileCreated = file.CreationTime,
                    });
                    // don't do that
                    // NotifyPropertyChanged("fileslist");
                }
                // publish them all to collection on UI thread
                OnUIThreadDo(() => {
                    foreach (var file in files)
                        Fileslist.Add(file);
                });
            }
        }
        private void OnUIThreadDo(Action a) {
            if (Application.Current.CheckAccess())
                a();
            else
                Application.Current.Dispatcher.BeginInvoke(a);
        }
        public void Dispose() {
            DisposeWatcher();
        }
        private void DisposeWatcher() {
            if (filewatcher != null) {
                filewatcher.EnableRaisingEvents = false;
                filewatcher.Created -= FileOnchanged;
                filewatcher.Deleted -= FileOnchanged;
                filewatcher.Changed -= FileOnchanged;
                filewatcher.Renamed -= FileOnRenamed;
                filewatcher.Dispose();
            }
        }
    }
    public class Files : INotifyPropertyChanged
    { // implement INotifyPropertyChanged, because you need to reflect property changes in UI
        public int FileId { get; set; }
        public string FullPath { get; set; }
        public string FileName => Path.GetFileName(FullPath);
        public DateTime FileChanged { get; set; }
        public DateTime FileCreated { get; set; }
        public string OnlyNameWithoutExtension => Path.GetFileNameWithoutExtension(FullPath);
    }
