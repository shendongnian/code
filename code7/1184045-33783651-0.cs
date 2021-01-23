    private void myKinectSensor_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (ColorImageFrame color = e.OpenColorImageFrame())
            {
                if (color != null)
                {
                    colorbits = new byte[color.PixelDataLength];
                    color.CopyPixelDataTo(colorbits);
                    image1.Source = BitmapSource.Create(color.Width, color.Height, 96, 96, PixelFormats.Bgr32, null, colorbits, color.Width * color.BytesPerPixel);
                    if (StartSavingFrames)
                    {
                        SaveColorTimestamps.AddLast(DateTime.Now.ToString("hhmmssfff"));
                        SaveColorFrames.AddLast(colorbits);
                    }
                }
            }
        }
