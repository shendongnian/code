        void Reader_MultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
        {
            var reference = e.FrameReference.AcquireFrame();
            using (var frame = reference.BodyFrameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    var body = frame.Bodies().Closest();
                    if (body != null)
                    {
                        JointType _start = JointType.SpineShoulder;
                        JointType _center = JointType.ShoulderRight;
                        JointType _end = JointType.ShoulderLeft;
                        double angle = body.Joints[_center].Angle(body.Joints[_start], body.Joints[_end]);
                        Point point = new Point();
                        ColorSpacePoint colorPoint = _sensor.CoordinateMapper.MapCameraPointToColorSpace(body.Joints[_center].Position);
                        point.X = float.IsInfinity(colorPoint.X) ? 0 : colorPoint.X;
                        point.Y = float.IsInfinity(colorPoint.Y) ? 0 : colorPoint.Y;
                        img.Source = new BitmapImage(new Uri("your-image-path", UriKind.RelativeOrAbsolute));
                        img.RenderTransformOrigin = new Point(0.5, 0.5);
                        img.RenderTransform = new RotateTransform(angle);
                        Canvas.SetLeft(img, point.X - img.Width / 2);
                        Canvas.SetTop(img, point.Y - img.Height / 2);
                    }
                }
            }
        }
