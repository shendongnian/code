    public async void showPicturesInGrid()
        {
            //Select folder
            StorageFolder folder1 = await KnownFolders.PicturesLibrary.GetFolderAsync("carpetaFunciona");
            //get all the pics in that folder
            List<IStorageItem> file = (await folder1.GetItemsAsync()).ToList();
            Debug.WriteLine(file.Count);
            if (file.Count > 0)
            {
                // if there are some pics, make a list to put them and a bitmap 
                // for each pic found, with its properties
                var images = new List<WriteableBitmap>();
                foreach (StorageFile f in file)
                {
                    var name = f.Name;
                    Debug.WriteLine(f.Name);
                    ImageProperties properties = await f.Properties.GetImagePropertiesAsync();
                    if (properties.Width > 0)
                    {
                        var bitmap = new WriteableBitmap((int)properties.Width, (int)properties.Height);
                        Debug.WriteLine(bitmap.PixelWidth);
                        using (var stream = await f.OpenAsync(FileAccessMode.ReadWrite))
                        {
                            bitmap.SetSource(stream);
                        }
                        // add the bitmaps to the list
                        images.Add(bitmap);
                        Debug.WriteLine(images.Count);
                    }
                }
                // Bind the list to the grid view
                AlGridView.DataContext = images;
            }
        }
