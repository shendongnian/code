    for (int i = 0; i < filesList.Count; i++)
                {
                    using (var stream = await filesList[i].OpenAsync(Windows.Storage.FileAccessMode.Read))
                    {
                        var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                        await bitmapImage.SetSourceAsync(stream);
                    }
                   
                }
