    Observable.FromEventPattern<FileSystemEventArgs>(FileSystemWatcher, "Created")
                    .Merge(Observable.FromEventPattern<FileSystemEventArgs>(FileSystemWatcher, "Changed"))
                    .Buffer(TimeSpan.FromSeconds(10))
                    .Where(list => list.Any())         //Add this line
                    .Subscribe(list =>
                    {
                       Debug.WriteLine("Do something");
                    });
