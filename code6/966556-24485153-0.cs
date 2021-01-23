        public static BitmapSource SnapShotToBitmap(this UIElement source, double zoomX, double zoomY)
        {
            try
            {
                DataObject dataObject = new DataObject();
                double actualHeight = source.RenderSize.Height;
                double actualWidth = source.RenderSize.Width;
                if (actualHeight == 0)
                    actualHeight = 1;
                if (actualWidth == 0)
                    actualWidth = 1;
                double renderHeight = actualHeight * zoomY;
                double renderWidth = actualWidth * zoomX;
                RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)renderWidth, (int)renderHeight, 96, 96, PixelFormats.Pbgra32);
                VisualBrush sourceBrush = new VisualBrush(source);
                DrawingVisual drawingVisual = new DrawingVisual();
                DrawingContext drawingContext = drawingVisual.RenderOpen();
                using (drawingContext)
                {
                    drawingContext.PushTransform(new ScaleTransform(zoomX, zoomY));
                    drawingContext.DrawRectangle(sourceBrush, null, new Rect(new Point(0, 0), new Point(actualWidth, actualHeight)));
                }
                renderTarget.Render(drawingVisual);
                return renderTarget;
            }
            catch (Exception e)
            {
                throw new Exception(e);
            }
        }
