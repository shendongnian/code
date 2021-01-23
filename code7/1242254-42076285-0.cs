    private Point BodyToColorPoint(Joint joint)
        {
            // 3D space point
            CameraSpacePoint jointPosition = joint.Position;
            // 2D space point
            Point point = new Point();
            //you need to change the Image and Canvas dimensions
            //because the resolution of Kinect2 color camera is 1920 X 1080 (too big for my screen)
            //if your canvas size is 960 X 540, should dived point.X and point.Y by 2
            if (_mode == CameraMode.Color)
            {
                ColorSpacePoint colorPoint = this.kinectSensor.CoordinateMapper.MapCameraPointToColorSpace(jointPosition);
                point.X = float.IsInfinity(colorPoint.X) ? 0 : colorPoint.X;
                point.Y = float.IsInfinity(colorPoint.Y) ? 0 : colorPoint.Y;
            }
            else if (_mode == CameraMode.Depth || _mode == CameraMode.Infrared) 
            {
                DepthSpacePoint depthPoint = this.kinectSensor.CoordinateMapper.MapCameraPointToDepthSpace(jointPosition);
                point.X = float.IsInfinity(depthPoint.X) ? 0 : depthPoint.X;
                point.Y = float.IsInfinity(depthPoint.Y) ? 0 : depthPoint.Y;
            }
            return point;
        }
