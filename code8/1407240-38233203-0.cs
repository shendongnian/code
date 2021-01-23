        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            var currentTime = DateTime.Now;
            var file = new FileInfo(e.FullPath);
            var createdDateTime = file.CreationTime;
            var span = createdDateTime.Subtract(currentTime);
            if (span.Minutes > 30)
            {
                // your code
            }
        }
