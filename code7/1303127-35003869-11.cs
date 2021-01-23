     private RelayCommand _loadedCommand;
        public RelayCommand LoadedCommand 
        {
            get
            {
                return _loadedCommand
                    ?? (_loadedCommand = new RelayCommand(
                    () =>
                    {
                        // Open image to writeablebitmap
                        string path = @"C:\Some\Path\To\ColorImage.png";
                        Stream imageStreamSource = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                        var decoder = new PngBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                        BitmapSource source = decoder.Frames[0];
                        int width = source.PixelWidth;
                        int height = source.PixelHeight;
                        int stride = source.Format.BitsPerPixel / 8 * width;
                        byte[] data = new byte[stride * height];
                        source.CopyPixels(data, stride, 0);
                        var cb = new WriteableBitmap(width, height, 96.0, 96.0, source.Format, null);
                        cb.WritePixels(new Int32Rect(0, 0, width, height), data, stride, 0);
                        ColourImage = cb;
                    }));
            }
        }
