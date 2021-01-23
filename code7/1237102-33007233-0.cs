    public void QueryPicturesToShow()
        {
            var pics = from medio in GlobalVariables.Medios
                       where medio.img != null
                       select new { Name = medio.name, Id = medio.id, Picture = medio.img };
            foreach (var item in pics)
            {
                Debug.WriteLine(item.Name);
                Debug.WriteLine(item.Id);
                Debug.WriteLine(item.Picture);
                savePicToDisk(item.Picture, item.Name, item.Id);
            }
        }
                    private async void savePicToDisk(string picAddress, string picName, string picId)
                    {
                        StorageFolder folder = await KnownFolders.PicturesLibrary.CreateFolderAsync("workingFolder", CreationCollisionOption.OpenIfExists);
                        
                        StorageFile file = await folder.CreateFileAsync((picName + picId + ".png"), CreationCollisionOption.ReplaceExisting);
                        string url = GlobalVariables.apiUrl + picAddress;
                        Debug.WriteLine(url);
                        HttpClient client = new HttpClient();
                        byte[] responseBytes = await client.GetByteArrayAsync(url);
                        var stream = await file.OpenAsync(FileAccessMode.ReadWrite);
                        using (var outputStream = stream.GetOutputStreamAt(0))
                        {
                            DataWriter writer = new DataWriter(outputStream);
                            writer.WriteBytes(responseBytes);
                            await writer.StoreAsync();
                            await outputStream.FlushAsync();
                            
                        }
        }
