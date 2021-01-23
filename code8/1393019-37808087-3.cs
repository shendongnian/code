     public sealed partial class MainPage : Page
        {
            bool pointerpressed = false;
            WriteableBitmap WB_CapturedImage;//for original image
            WriteableBitmap WB_CroppedImage;//for cropped image
            Point Point1, Point2;
            public MainPage()
            {
                this.InitializeComponent();
               // view = CoreApplication.GetCurrentView();
                this.NavigationCacheMode = NavigationCacheMode.Required;
                CompositionTarget.Rendering += CompositionTarget_Rendering;
            }
    
            void CompositionTarget_Rendering(object sender, object e)
            {
                rect.SetValue(Canvas.LeftProperty, (Point1.X < Point2.X) ? Point1.X : Point2.X);
                rect.SetValue(Canvas.TopProperty, (Point1.Y < Point2.Y) ? Point1.Y : Point2.Y);
                rect.Width = (int)Math.Abs(Point2.X - Point1.X);
                rect.Height = (int)Math.Abs(Point2.Y - Point1.Y);
            }
        //To generate croping rectangle
        private void Rectangle_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
                {
                    Point1 = e.Position;//Set first touchable cordinates as point1
                    Point2 = Point1;
                }
        
                private void Rectangle_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
                {
                    var point = Point2;
                    if (e.Position.X <= original.ActualWidth && e.Position.X >= 0)
                        point.X = e.Position.X;
                    if (e.Position.Y <= original.ActualHeight && e.Position.Y >= 0)
                        point.Y = e.Position.Y;
                    Point2 = point;
                }
        
                private void Rectangle_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
                {
                    var point = Point2;
                   // Debug.WriteLine(e.Position.X + "&&&" + original.ActualWidth);
                    if (e.Position.X <= original.ActualWidth && e.Position.X>=0)
                        point.X = e.Position.X;
                    if (e.Position.Y <= original.ActualHeight && e.Position.Y >= 0)
                        point.Y = e.Position.Y;
                    Point2 = point;
                }
        
                private void rect_PointerPressed(object sender, PointerRoutedEventArgs e)
                {
                    pointerpressed = true;
                    Point1 = e.GetCurrentPoint(original).Position;//Set first touchable cordinates as point1
                    Point2 = Point1;
                }
     private async void CropBtn_Click(object sender, RoutedEventArgs e)
            {
                BitmapDecoder decoder = null;
                BitmapImage bImage = original.Source as BitmapImage;
    
                if (storageFile == null && bImage.UriSource!=null)
                {
                    storageFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx://"+bImage.UriSource.AbsolutePath));
                }
                
                using (IRandomAccessStream streamWithContent = await storageFile.OpenAsync(FileAccessMode.Read))
                {        
                    decoder = await BitmapDecoder.CreateAsync(streamWithContent);
                    BitmapFrame bitmapFrame = await decoder.GetFrameAsync(0);
                    WB_CapturedImage = new WriteableBitmap((int)bitmapFrame.PixelWidth,
                                                                 (int)bitmapFrame.PixelHeight);
                    Size cropsize = new Size(Math.Abs(Point2.X - Point1.X), Math.Abs(Point2.Y - Point1.Y));
                    double originalImageWidth = WB_CapturedImage.PixelWidth;
                    double originalImageHeight = WB_CapturedImage.PixelHeight;
    
                    // Get the size of the image when it is displayed on the phone
                    double displayedWidth = original.ActualWidth;
                    double displayedHeight = original.ActualHeight;
    
                    // Calculate the ratio of the original image to the displayed image
                    double widthRatio = originalImageWidth / displayedWidth;
                    double heightRatio = originalImageHeight / displayedHeight;
                    WB_CroppedImage = await GetCroppedBitmapAsync(streamWithContent, Point1, cropsize, widthRatio, heightRatio);
                    
                    FinalCroppedImage.Source = WB_CroppedImage;
                }
            }
     public static async Task<WriteableBitmap> GetCroppedBitmapAsync(IRandomAccessStream originalImage,
           Point startPoint, Size cropSize, double scaleWidth, double scaleheight)
        {
            if (double.IsNaN(scaleWidth) || double.IsInfinity(scaleWidth))
            {
                scaleWidth = 1;
            }
            if (double.IsNaN(scaleheight) || double.IsInfinity(scaleheight))
            {
                scaleheight = 1;
            }
            // Convert start point and size to integer.
            var startPointX = (uint)Math.Floor(startPoint.X * scaleWidth);
            var startPointY = (uint)Math.Floor(startPoint.Y * scaleheight);
            var height = (uint)Math.Floor(cropSize.Height * scaleheight);
            var width = (uint)Math.Floor(cropSize.Width * scaleWidth);
            // Create a decoder from the stream. With the decoder, we can get 
            // the properties of the image.
            var decoder = await BitmapDecoder.CreateAsync(originalImage);
            // The scaledSize of original image.
            var scaledWidth = (uint)(decoder.PixelWidth);
            var scaledHeight = (uint)(decoder.PixelHeight);
            // Refine the start point and the size. 
            if (startPointX + width > scaledWidth)
            {
                startPointX = scaledWidth - width;
            }
            if (startPointY + height > scaledHeight)
            {
                startPointY = scaledHeight - height;
            }
            // Get the cropped pixels.
            var pixels = await GetPixelData(decoder, startPointX, startPointY, width, height,
                scaledWidth, scaledHeight);
            // Stream the bytes into a WriteableBitmap
            var cropBmp = new WriteableBitmap((int)width, (int)height);
            var pixStream = cropBmp.PixelBuffer.AsStream();
            pixStream.Write(pixels, 0, (int)(width * height * 4));
            return cropBmp;
        }
     private static async Task<byte[]> GetPixelData(BitmapDecoder decoder, uint startPointX, uint startPointY,
              uint width, uint height, uint scaledWidth, uint scaledHeight)
            {
                var transform = new BitmapTransform();
                var bounds = new BitmapBounds();
                bounds.X = startPointX;
                bounds.Y = startPointY;
                bounds.Height = height;
                bounds.Width = width;
                transform.Bounds = bounds;
    
                transform.ScaledWidth = scaledWidth;
                transform.ScaledHeight = scaledHeight;
    
                // Get the cropped pixels within the bounds of transform.
                var pix = await decoder.GetPixelDataAsync(
                    BitmapPixelFormat.Bgra8,
                    BitmapAlphaMode.Premultiplied,
                    transform,
                    ExifOrientationMode.IgnoreExifOrientation,
                    ColorManagementMode.ColorManageToSRgb);
                var pixels = pix.DetachPixelData();
                return pixels;
            }
    }
