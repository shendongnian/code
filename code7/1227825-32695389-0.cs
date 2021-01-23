       private static void SnapShotPNG(ListView source, string destination, int zoom)
            {
                try
                {
                    double actualWidth = source.ActualWidth;
                    source.Measure(new Size(source.ActualWidth, Double.PositiveInfinity));
                    source.Arrange(new Rect(0, 0, actualWidth, source.DesiredSize.Height));
                    double actualHeight = source.ActualHeight;
    
                    double renderHeight = actualHeight * zoom;
                    double renderWidth = actualWidth * zoom;
    
                    RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)renderWidth, (int)renderHeight, 96, 96, PixelFormats.Pbgra32);
                    VisualBrush sourceBrush = new VisualBrush(source);
    
                    DrawingVisual drawingVisual = new DrawingVisual();
                    DrawingContext drawingContext = drawingVisual.RenderOpen();
    
                    using (drawingContext)
                    {
                        drawingContext.PushTransform(new ScaleTransform(zoom, zoom));
                        drawingContext.DrawRectangle(sourceBrush, null, new Rect(new Point(0, 0), new Point(actualWidth, actualHeight)));
                    }
                    renderTarget.Render(drawingVisual);
    
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(renderTarget));
                    using (FileStream stream = new FileStream(destination, FileMode.Create, FileAccess.Write))
                    {
                        encoder.Save(stream);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
