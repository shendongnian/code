    if (usbCams.Count == 1)
    {
        cam = new VideoCaptureDevice(usbCams[0].MonikerString);
    }
    else if (usbCams.Count == 2)
    {
        cam = new VideoCaptureDevice(usbCams[1].MonikerString);
    }
