        private BitmapImage GetThumbnailFromCameraRoll(string path)
        {
            MediaLibrary mediaLibrary = new MediaLibrary();
            var pictures = mediaLibrary.Pictures;
            foreach (var picture in pictures)
            {
                var camerarollPath = picture.GetPath();
                if (camerarollPath == path)
                {
                    BitmapImage image = new BitmapImage();
                    image.SetSource(picture.GetThumbnail());
                    return image;
                }
            }
            return null;
        }
