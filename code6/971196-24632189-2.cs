    void ExternOpen(FileHeader header)
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var appDataLocation = appData + @"\" + header;
            using (var fs = new FileStream(appDataLocation, FileMode.Create, FileAccess.Write, FileShare.ReadWrite | FileShare.Delete))
            using (var hs = header.GetStream())
            {
                hs.CopyTo(fs);
                Process.Start(appDataLocation);
            }
        }
