    private void Reader_FrameArrived(object sender, MultiSourceFrameArrivedEventArgs e) {
       
        using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame().BodyFrameReference.AcquireFrame()) {
            // do something
        }
        using (DepthFrame depthFrame = e.FrameReference.AcquireFrame().DepthFrameReference.AcquireFrame()) {
            // do something
        }
    }
