            private async void GetGirlsTimes()
            {
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                try
                {
                    StorageFile textFile = await localFolder.GetFileAsync("GirlsTimes.xml");
                    using (IRandomAccessStream textStream = await textFile.OpenReadAsync())
                    {
                        Stream s = textStream.AsStreamForRead();
                        loadedData = XDocument.Load(s);
                    }
                }
                catch
                {
                    storageFolder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("AppData");
                    storageFile = await storageFolder.GetFileAsync("GirlsTimes.xml");
                    using (IRandomAccessStream writeStream = await storageFile.OpenAsync(FileAccessMode.Read))
                    {
                        Stream s = writeStream.AsStreamForRead();
                        loadedData = XDocument.Load(s);
                    }
                }
                finally
                {
                   ...//put the value from loadedData to my differents TextBoxes.
                }
            }
