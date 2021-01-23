    private void MsgCallback(object o, MessageArgs args) {
        // Only care about window ID binding requests.
    
        Gst.Message msg = args.Message;
        if (! Gst.Video.Global.IsVideoOverlayPrepareWindowHandleMessage(msg))
            return;
    
        // Get bin, interface element, then notify it to bind.
    
        Gst.Bin src = (Gst.Bin)(this.playbin);
        Gst.Element ov = src.GetByInterface(VideoOverlayAdapter.GType);
        VideoOverlayAdapter ad = new VideoOverlayAdapter(ov.Handle);
        ad.WindowHandle = windowXId;
    }
