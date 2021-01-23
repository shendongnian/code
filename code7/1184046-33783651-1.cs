    private void myKinectSensor_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            using (DepthImageFrame depth = e.OpenDepthImageFrame())
            {
                depthPixels = new DepthImagePixel[myKinectSensor.DepthStream.FramePixelDataLength];
                if (depth != null)
                {
                    frame = new short[depth.PixelDataLength];
                    depth.CopyPixelDataTo(frame);
                    for (int i = 0; i < frame.Length; i++)
                    {
                        frame[i] = (short)(((ushort)frame[i]) >> 3);
                    }
                    image3.Source = BitmapSource.Create(depth.Width, depth.Height, 96, 96, PixelFormats.Gray16, null, frame, depth.Width * depth.BytesPerPixel);
                    if (StartSavingFrames)
                    {
                        SaveDepthTimestamps.AddLast(DateTime.Now.ToString("hhmmssfff"));
                        SaveDepthFrames.AddLast(frame);
                    }
                }
            }
        }
