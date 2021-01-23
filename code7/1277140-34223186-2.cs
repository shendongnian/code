            double skewX = .0;
            double skewY = Math.Tan(Math.PI / 18);
            MatrixTransform transformation = new MatrixTransform(1, skewY, skewX, 1, 0, 0)
            BitmapImage image = new BitmapImage(new Uri(@"D:\input.png"));
            var boundingRect = new Rect(0, 0, image.Width + image.Height * skewX, image.Height + image.Width * skewY);
            DrawingGroup dGroup = new DrawingGroup();
            using (DrawingContext dc = dGroup.Open())
            {
                dc.PushTransform(transformation);
           
                dc.DrawImage(image, boundingRect);
            }
           
            DrawingImage imageSource = new DrawingImage(dGroup);
       
            imgProcess.Source = imageSource;
            SaveDrawingToFile(ToBitmapSource(imageSource), @"D:\skew.png", (int)boundingRect.Width, (int)boundingRect.Height);
        private BitmapSource ToBitmapSource(DrawingImage source)
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            drawingContext.DrawImage(source, new Rect(new Point(0, 0), new Size(source.Width, source.Height)));
            drawingContext.Close();
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)source.Width, (int)source.Height, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);
            return bmp;
        }
        private void SaveDrawingToFile(BitmapSource image, string fileName, int width, int height)
        {
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                encoder.Save(stream);
            }
        }
