    private async Task UnZipFile()
    {
        // you can use Isolated storage too
        var myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
        using (var fileStream = Application.GetResourceStream(new Uri("sample.zip", UriKind.Relative)).Stream)
        {
            var unzip = new UnZipper(fileStream);
            foreach (string filename in unzip.FileNamesInZip)
            {
                if (!string.IsNullOrEmpty(filename))
                {
                    if (filename.Any(m => m.Equals('/')))
                    {
                        myIsolatedStorage.CreateDirectory(filename.Substring(0, filename.LastIndexOfAny(new char[] { '/' })));
                    }
                    //save file entry to storage
                    using (var streamWriter =
                        new StreamWriter(new IsolatedStorageFileStream(filename,
                            FileMode.Create,
                            FileAccess.ReadWrite,
                            myIsolatedStorage)))
                    {
                        streamWriter.Write(unzip.GetFileStream(filename));
                    }
                }
            }
        }
    }
