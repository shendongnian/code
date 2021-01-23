    public static void StrPath2ResizedImgSize(Image img, string strPath, int newWidth, int newHeight)
    {
      img.Source = BitmapUtilities.StrPath2ResizedBmpSize(strPath, newWidth, newHeight);
    }
    ImageUtilities.StrPath2ResizedImgSize(LogoImage, strFilename, 50, 50);
