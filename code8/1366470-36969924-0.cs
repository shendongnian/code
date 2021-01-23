    var lines = await Windows.Storage.FileIO.ReadLinesAsync(App.ProgramsIndex, Windows.Storage.Streams.UnicodeEncoding.Utf8);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                {
                    //Skip This Line
                }
                else
                {
                    //Do whatever you want .
                    Windows.Storage.StorageFile.GetFileFromPathAsync(line);
                }
            }
