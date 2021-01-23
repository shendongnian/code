    private async Task<byte[]> ConvertImagetoByte(StorageFile image)
    {
                IRandomAccessStream fileStream = await image.OpenAsync(FileAccessMode.Read);
                var reader = new Windows.Storage.Streams.DataReader(fileStream.GetInputStreamAt(0));
                await reader.LoadAsync((uint)fileStream.Size);
    
                byte[] pixels = new byte[fileStream.Size];
    
                reader.ReadBytes(pixels);
    
                return pixels;
    
    }
    
    private async void btnSave_Click(object sender, RoutedEventArgs e)
    {
                try
                {
                    var uri = new Uri("ms-appx:///images/image.jpg");
                    var img = await StorageFile.GetFileFromApplicationUriAsync(uri);
                    byte[] responseBytes = await ConvertImagetoByte(img);
    
                    var image_folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("images", CreationCollisionOption.OpenIfExists);
    
                    StorageFile file = await image_folder.CreateFileAsync("image_test.jpg", CreationCollisionOption.ReplaceExisting);
                    await FileIO.WriteBytesAsync(file, responseBytes);
    
                    tmp.Source = new BitmapImage(new Uri("ms-appdata:///local/images/image_test.jpg", UriKind.Absolute));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
    }
