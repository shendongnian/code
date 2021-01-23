    BitmapImage bitmapImage = new BitmapImage();
    try
            {
                using (StorageItemThumbnail thumbnail = await receivedFile.GetThumbnailAsync(ThumbnailMode.MusicView, 300))
                {
                    if (thumbnail != null && thumbnail.Type == ThumbnailType.Image)
                    {
                        bitmapImage.SetSource(thumbnail);
                    }
                }
            }
            catch (Exception)
            {
                bitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/NoAlbumArt.png"));
            }
            AlbumArt.Source = bitmapImage;
