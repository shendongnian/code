    private int IsImageReady= 0; 
    private void Camera_FrameReady(object Sender, ImageEvent e){
      int wasImageReady = Interlocked.Exchange(ref IsImageReady, 1);
      if (wasImageReady ==1) return;
        //do something
        IsImageReady= 0;
      }
    }
