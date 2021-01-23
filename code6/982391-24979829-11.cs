    public static Bitmap SmartResize(string strImageFile, Size objMaxSize, ImageFormat enuType)
    {
        Bitmap objImage = null;
        try
        {
            objImage = new Bitmap(strImageFile);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        if (objImage.Width > objMaxSize.Width || objImage.Height > objMaxSize.Height)
        {
            Size objSize;
            int intWidthOverrun = 0;
            int intHeightOverrun = 0;
            if (objImage.Width > objMaxSize.Width)
                intWidthOverrun = objImage.Width - objMaxSize.Width;
            if (objImage.Height > objMaxSize.Height)
                intHeightOverrun = objImage.Height - objMaxSize.Height;
            double dblRatio;
            double dblWidthRatio = (double)objMaxSize.Width / (double)objImage.Width;
            double dblHeightRatio = (double)objMaxSize.Height / (double)objImage.Height;
            if (dblWidthRatio < dblHeightRatio)
                dblRatio = dblWidthRatio;
            else
                dblRatio = dblHeightRatio;
            objSize = new Size((int)((double)objImage.Width * dblRatio), (int)((double)objImage.Height * dblRatio));
            Bitmap objNewImage = Resize(objImage, objSize, enuType);
            objImage.Dispose();
            return objNewImage;
        }
        else
        {
            return objImage;
        }
    }
