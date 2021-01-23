    public System.Drawing.Image GetImage(string sOriginalPath, string sLogoPath)
    {
      System.Drawing.Image imgOriginal = System.Drawing.Image.FromFile(sOriginalPath, true);
      using (System.Drawing.Image imgLogo = System.Drawing.Image.FromFile(sLogoPath, true)) //This is where it throws the exception
      {
        using (Graphics gra = Graphics.FromImage(imgOriginal))
        {
          using(Bitmap bmLogo = new Bitmap(imgLogo)) 
          {
            int nWidth = bmLogo.Size.Width;
            int nHeight = bmLogo.Size.Height;
            int nLeft = (imgOriginal.Width / 2) - (nWidth / 2);
            int nTop = (imgOriginal.Height / 2) - (nHeight / 2);
            gra.DrawImage(bmLogo, nLeft, nTop, nWidth, nHeight);
          }
        }
      }
      return imgOriginal;
    }
