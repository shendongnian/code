    void KinectPointerPointSample_Loaded(object sender, RoutedEventArgs e)
        {
            // Listen to Kinect pointer events
            KinectCoreWindow kinectCoreWindow = KinectCoreWindow.GetForCurrentThread();
            kinectCoreWindow.PointerMoved += kinectCoreWindow_PointerMoved;
        }
        private void kinectCoreWindow_PointerMoved(object sender, KinectPointerEventArgs args)
        {
            KinectPointerPoint kinectPointerPoint = args.CurrentPoint;
            
            bool isEngaged = kinectPointerPoint.Properties.IsEngaged;
            if (isEngaged)
            {
                System.Drawing.Point mousePt = new System.Drawing.Point((int)(kinectPointerPoint.Position.X * kinectRegion.ActualWidth - 80), (int)(kinectPointerPoint.Position.Y * kinectRegion.ActualHeight));
                System.Windows.Forms.Cursor.Position = mousePt;
            }            
        }
