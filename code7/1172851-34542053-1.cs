    private enum CaptureType
    {
        AllScreens,
        PrimaryScreen,
        VirtualScreen,
        WorkingArea
    }
    private static Bitmap[] Capture(CaptureType typeOfCapture)
    {
        Bitmap[] images = null;
        Bitmap memoryImage;
        int count = 1;
                
        Screen[] screens = Screen.AllScreens;
        Rectangle SourceRectangle;
    
        switch (typeOfCapture)
        {
            case CaptureType.PrimaryScreen:
                SourceRectangle = Screen.PrimaryScreen.Bounds;
                break;
            case CaptureType.VirtualScreen:
                SourceRectangle = SystemInformation.VirtualScreen;
                break;
            case CaptureType.WorkingArea:
                SourceRectangle = Screen.PrimaryScreen.WorkingArea;
                break;
            case CaptureType.AllScreens:
                count = screens.Length;
                typeOfCapture = CaptureType.WorkingArea;
                SourceRectangle = screens[0].WorkingArea;
                break;
            default:
                SourceRectangle = SystemInformation.VirtualScreen;
                break;
        }
    
        // allocate a member for saving the captured image(s)
        images = new Bitmap[count];
    
        // cycle across all desired screens
        for (int index = 0; index < count; index++)
        {
            if (index > 0)
            {
                SourceRectangle = screens[index].WorkingArea;
            }
    
            // redefine the size on multiple screens
            memoryImage = new Bitmap(SourceRectangle.Width, SourceRectangle.Height, PixelFormat.Format32bppArgb);
    
            using (Graphics memoryGrahics = Graphics.FromImage(memoryImage))
            {
                memoryGrahics.CopyFromScreen(SourceRectangle.X, SourceRectangle.Y, 0, 0, SourceRectangle.Size, CopyPixelOperation.SourceCopy);
            }
    
            images[index] = memoryImage;
        }
    
        return images;
    }
