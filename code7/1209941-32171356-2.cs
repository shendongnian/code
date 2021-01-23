    private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
    {
        PushNextFrame((Bitmap)eventArgs.Frame.Clone());
    }
    
    Bitmap nextFrame;
    
    void PushNextFrame(Bitmap value)
    {
    	var prevFrame = Interlocked.Exchange(ref nextFrame, value);
    	if (prevFrame != null)
    	{
    		// previous frame has not been consumed, so just discard it.
    		// no need to notify the consumer, because it should have been done already.
    		prevFrame.Dispose();
    	}
    	else
    	{
    		// previos frame has been consumed and we just set a new one, so we need to notity the consumer.
    		BeginInvoke((Action)OnNextFrameAvailable);
    	}
    }
    
    Bitmap PullNextFrame() { return Interlocked.Exchange(ref nextFrame, null); }
    
    void OnNextFrameAvailable()
    {
    	DisplayFrame(PullNextFrame());
    }
    
    Bitmap currentFrame;
    
    void DisplayFrame(Bitmap value)
    {
    	pb_Camera.Image = value;
    	if (currentFrame != null) currentFrame.Dispose();
    	currentFrame = value;
    }
