    // Update the image, method called by the timer every 10 ms 
    private void UpdateImage()
    {
        // If capture is working
        if(capture.QueryFrame()!= null)
        {
            //capture an Image from webcam stream and 
            Image<Bgr, Byte> currentFrame = capture.QueryFrame().ToImage<Bgr, Byte>();
            if (currentFrame != null)
            {
                Application.Current.Dispatcher.BeginInvoke(new System.Action(() => { imageWebcam = new WriteableBitmap(BitmapSourceConvert.ToBitmapSource(currentFrame)); NotifyOfPropertyChange(() => ImageWebcam); }));
            }
        }
    }
