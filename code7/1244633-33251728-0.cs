            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            var path = localFolder.Path;
            await Task.Run(() =>
            {
                using (TextWriter writer = File.CreateText(Path.Combine(path, "IPC_File.s")))
                {
                    writer.Write("Hello World");
                }
            });
