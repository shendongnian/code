        // Reference to the single KinectSensor object
        private KinectSensor kinectSensor;
        // Local variables with depth, color and skeletal information
        private Skeleton[] skeleton_thread1;
        private Skeleton[] skeleton_thread2;
        private short[] depth_thread1;
        private short[] depth_thread2;
        private byte[] color_thread1;
        private byte[] color_thread2;
        // ...
        // Register callbacks (you must so this both in thread1 and thread2)
        // Assume that here we are refererring to thread1
        kinectSensor.ColorFrameReady += new EventHandler<ColorFrameReadyEventArgs>(kinectSensor_ColorFrameReady1);
        kinectSensor.DepthFrameReady += new EventHandler<DepthFrameReadyEventArgs>(kinectSensor_DepthFrameReady1);
        kinectSensor.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(kinectSensor_SkeletonFrameReady1);
        // ...
        private void kinectSensor_SkeletonFrameReady1(object sender, SkeletonFrameReadyEventArgs e)
        {
            this.skeletonFrame_thread1 = 
            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    this.skeleton_thread1 = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(this.skeleton_thread1);
                    
                    // Do stuff
                }
                else
                {
                    // Do stuff
                }
            }
        }
        private void kinectSensor_ColorFrameReady1(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (ColorImageFrame colorImageFrame = e.OpenColorImageFrame())
            {
                if (colorImageFrame != null)
                {
                    this.color_thread1 = new byte[colorImageFrame.PixelDataLength];
                    colorImageFrame.CopyPixelDataTo(this.color_thread1);
                    // Do Stuff
                }
                else
                {
                    // Do stuff
                }
            }
        }
        private void kinectSensor_DepthFrameReady1(object sender, DepthImageFrameReadyEventArgs e)
        {
            using (DepthImageFrame depthImageFrame = e.OpenDepthImageFrame())
            {
                if (depthImageFrame != null)
                {
                    this.depth_thread1 = new short[depthImageFrame.PixelDataLength];
                    depthImageFrame.CopyPixelDataTo(this.depth_thread1);
                    // Do Stuff
                }
                else
                {
                    // Do stuff
                }
            }
        }
