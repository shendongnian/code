    /*Polling event to retrieve Data from Kinect*/
        private void Pulse()
        {
          
            using (ColorImageFrame imageFrame = _kinectSensor.ColorStream.OpenNextFrame(200))
            {
                if (imageFrame == null)
                    return;
                //Converting a Kinect Color Frame to EmguCV Image
                Image<Bgr, Byte> imageCap = imageFrame.ToOpenCVImage<Bgr, Byte>();
                Image<Gray, Byte> gray = imageCap.Convert<Gray, Byte>();
                corners = CameraCalibration.FindChessboardCorners(gray, boardSize, Emgu.CV.CvEnum.CALIB_CB_TYPE.ADAPTIVE_THRESH | Emgu.CV.CvEnum.CALIB_CB_TYPE.FILTER_QUADS);
                if (corners != null)
                {
                    CvInvoke.cvFindCornerSubPix(gray, corners, corners.Length, new Drawing.Size(11, 11), new Drawing.Size(-1, -1), new MCvTermCriteria(30, 0.1));
                    CameraCalibration.DrawChessboardCorners(gray, boardSize, corners);
                    pixelWidth = gray.ToBitmapSource().PixelWidth;
                    pixelHeight = gray.ToBitmapSource().PixelHeight;
                    //Displaying the result in WPF
                    this.Dispatcher.Invoke(
                           new Action(() => rgbImage.Source = gray.ToBitmapSource())
                           );
                }
                else
                {
                    //Displaying the result in WPF
                    this.Dispatcher.Invoke(
                           new Action(() => rgbImage.Source = gray.ToBitmapSource())
                           );
                   
                }
            }
        }
        private void rgbImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point p = Mouse.GetPosition(rgbImage);
          
            var pixelMousePosX = e.GetPosition(rgbImage).X * pixelWidth / rgbImage.ActualWidth;
            var pixelMousePosY = e.GetPosition(rgbImage).Y * pixelHeight / rgbImage.ActualHeight;
            Console.WriteLine("MousePixelX: " + pixelMousePosX + "," + "MousePixelY: " + pixelMousePosY);
            /*Test Square */
            for (int c = 0; c < rectangle.Count; c++)
            {
                for (int n = 0; n < 4; n++)
                {
                    if ((pixelMousePosX > rectangle[c][0].X && pixelMousePosX < rectangle[c][1].X) && (pixelMousePosY > rectangle[c][0].Y && pixelMousePosY < rectangle[c][2].Y))
                    {
                        Console.WriteLine("Triangle HIT is triangle no: " + c);
                    }
                }
            }
        }
