    class Form1 : Form // making assumption your code is in a Form
    {
        ColorSpacePoint? PreviousPoint;
        // I have no idea what the actual event handler is supposed to look like.
        // This is just a wild guess based on the little bit of code you posted.
        void KinectEventHandler(object sender, KinectEventArgs handtip)
        {
            CameraSpacePoint handtipPosition = handtip.Position;
            ColorSpacePoint handtipPoint = _sensor.CoordinateMapper
                .MapCameraPointToColorSpace(handtipPosition);
            if (PreviousPoint != null)
            {
                ColorSpacePoint previousPointValue = (ColorSpacePoint)PreviousPoint;
                line.X1 = previousPointValue.X;
                line.Y1 = previousPointValue.Y;
                line.X2 = handtipPoint.X;                                 
                line.Y2 = handtipPoint.Y;                            
                canvas.Children.Add(line);
            }
            PreviousPoint = handtipPoint;                        
        }
    }
