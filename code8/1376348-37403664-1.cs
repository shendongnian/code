    var newFrame = (Bitmap)eventArgs.Frame.Clone();
    if (livePreview.Image != null)
    {
        //Dispose the resources
        this.Invoke(new MethodInvoker(delegate() { 
            livePreview.Image.Dispose(); 
            livePreview.Image = newFrame;
        }));
    }
    
