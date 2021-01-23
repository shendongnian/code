        public object FileLocation
        {
            get
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(Path);
                image.EndInit();
                return image;
            }
        }
