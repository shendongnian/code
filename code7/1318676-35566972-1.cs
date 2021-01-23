    private void MessageCallback(object o, MessageArgs args) {
        Gst.Message msg = args.Message;
        if (! Gst.Video.Global.IsVideoOverlayPrepareWindowHandleMessage(msg))
            return;
        Gst.Element src = msg.Src as Gst.Element;
        if (src == null)
            return;
        Gst.Element overlay = null;
        if (src is Gst.Bin)
            overlay = ((Gst.Bin)src).GetByInterface
        Gst.Video.VideoOverlayAdapter = new Gst.Video.VideoOverlayAdapter(overlay.Handle);
        adapter.WindowHandle = windowXid;
    }
