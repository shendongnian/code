    var newFrame = (Bitmap)eventArgs.Frame.Clone();
    this.Invoke(new MethodInvoker(delegate() { 
        if (livePreview.Image != null)
        {
            livePreview.Image.Dispose(); 
        }
        livePreview.Image = newFrame;
    }));
