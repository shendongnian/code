           private void InitializeKinect()
            {
                KinectSensor Sensor = KinectSensor.GetDefault();
                FrameDescription frameDescription = Sensor.ColorFrameSource.FrameDescription;
                ColorFrameReader FrameReader = Sensor.ColorFrameSource.OpenReader();
                FrameReader.FrameArrived += FrameReader_FrameArrived;
              }
            void FrameReader_FrameArrived(object sender, ColorFrameArrivedEventArgs e)
            {
                using (ColorFrame frame = e.FrameReference.AcquireFrame())
                {
                    if (frame == null)
                        return;
                var width = frame.FrameDescription.Width;
                var heigth = frame.FrameDescription.Height;
                var data = new byte[width * heigth * System.Windows.Media.PixelFormats.Bgra32.BitsPerPixel / 8];
                frame.CopyConvertedFrameDataToArray(data, ColorImageFormat.Bgra);
                  
                var bitmap = new System.Drawing.Bitmap(width, height, PixelFormat.Format32bppRgb);
                var bitmapData = bitmap.LockBits(
                    new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    ImageLockMode.WriteOnly,
                    bitmap.PixelFormat);
                Marshal.Copy(data, 0, bitmapData.Scan0, data.Length);
                bitmap.UnlockBits(bitmapData);
                  
                  Emgu.CV.Image<Bgr, Byte> imageFrame = new Image<Bgr, Byte>(bitmap);
                    
                }
            }
